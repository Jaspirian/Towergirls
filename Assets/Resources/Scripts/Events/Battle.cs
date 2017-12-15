﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    private const int NUM_DISPLAYED = 6;

    private List<Battler> initialFighters;
    private List<Battler> currentFighters;

    public GameObject triangle;

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        WIN,
        LOSE
    }
    public BattleStates currentState;

    // Use this for initialization
    void Start() {
        currentState = BattleStates.START;
        initialFighters = getFighters();
        currentFighters = getFighters();
        currentFighters.Sort(delegate (Battler a, Battler b)
        {
            return a.entity.stats.speed.getCurrent().CompareTo(b.entity.stats.speed.getCurrent());
        });
        displayHeads(currentFighters);
        foreach (Battler battler in currentFighters)
        {
            battler.show();
        }
        triangle.SetActive(true);
        moveTriangle(currentFighters[0]);
    }

    // Update is called once per frame
    void Update() {

        if (currentState == BattleStates.START)
        {
            if (currentFighters[0].entity.isPlayerControlled) {
                currentState = BattleStates.PLAYERCHOICE;
            } else {
                currentState = BattleStates.ENEMYCHOICE;
            }
        } else if (currentState == BattleStates.PLAYERCHOICE)
        {
            updateUI(currentFighters[0]);
        } else if (currentState == BattleStates.ENEMYCHOICE)
        {
            enemyTurn(currentFighters[0]);
        } else if (currentState == BattleStates.WIN)
        {
            playWin();
        } else
        {
            playLoss();
        }
    }

    private List<Battler> getFighters()
    {
        List<Battler> temp = new List<Battler>();
        //THIS IS PLACEHOLDER STUFF
        temp.Add(new Battler(new Knight("Sir Knight", true), new Vector3(0, 1, 1)));
        temp.Add(new Battler(new Enemy("Bandit Male", false), new Vector3(1, 0, 0)));
        temp.Add(new Battler(new Enemy("Bandit Spike", true), new Vector3(1, 1, 1)));
        temp.Add(new Battler(new Enemy("Bandit Female", true), new Vector3(1, 0, 2)));
        //
        return temp;
    }

    private void displayHeads(List<Battler> order)
    {
        int j = 0;
        for(int i=0; i<NUM_DISPLAYED; i++)
        {
            GameObject head = GameObject.Find("/Battle/Turn order/" + (i + 1));
            //Debug.Log(head);
            Sprite sprite = null;
            if (j >= order.Count) j = 0;
            //Debug.Log(j);
            sprite = order[j].entity.sprite;
            //Debug.Log(sprite);
            head.GetComponent<SpriteRenderer>().sprite = sprite;
            j++;
        }
    }

    private void moveTriangle(Battler currentFighter)
    {
        Vector3 spriteLoc = currentFighter.battleSprite.transform.position;
        int xOffset = 0;
        int yOffset = 1;
        triangle.transform.position = new Vector3(spriteLoc.x + xOffset, spriteLoc.y + yOffset, triangle.transform.position.z);
    }

    private void updateUI(Battler currentFighter)
    {
        GameObject.Find("Canvas/Bottom/Character/Avatar").GetComponent<Image>().sprite = currentFighter.entity.sprite;
        GameObject.Find("Canvas/Bottom/Character/Name").GetComponent<Text>().text = currentFighter.entity.title;
        GameObject.Find("Canvas/Bottom/Character/Name").GetComponent<Text>().color = Color.black;
        Debug.Log(currentFighter.entity.color);
        //if(currentFighter.entity.color != null) GameObject.Find("Canvas/Bottom/Character/Name").GetComponent<Text>().color = currentFighter.entity.color;
    }

    private void enemyTurn(Battler currentFighter)
    {

    }

    private void playWin()
    {

    }

    private void playLoss()
    {

    }

    private void nextTurn()
    {
        Battler justWent = currentFighters[0];
        currentFighters.RemoveAt(0);
        currentFighters.Add(justWent);

        displayHeads(currentFighters);
    }
}