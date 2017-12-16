using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    private const int NUM_DISPLAYED = 6;

    private List<Battler> initialFighters;
    private List<Battler> currentFighters;

    public GameObject triangle;

    public Card card;
    public GameObject dialogueLayout;
    public GameObject fightLayout;

    public Toggle melee;
    public Toggle spells;
    public Toggle items;

    // Use this for initialization
    void Start() {
        card = GameObject.Find("Canvas/Right/Card").GetComponent<Card>();
        
        initialFighters = getFighters();
        currentFighters = getFighters();
        currentFighters.Sort(delegate (Battler a, Battler b)
        {
            int speedA = a.entity.stats.speed.getCurrent();
            int speedB = b.entity.stats.speed.getCurrent();
            if (speedA > speedB) return -1;
            if (speedA < speedB) return 1;
            return 0;
        });
        displayHeads(currentFighters);
        foreach (Battler battler in currentFighters)
        {
            battler.show(card);
        }
        triangle.SetActive(true);
        moveTriangle(currentFighters[0]);
        updateSelected(currentFighters[0]);
        card.selected = currentFighters[0].entity;
        card.Reset();

        if (currentFighters[0].entity.isPlayerControlled) playerTurn(currentFighters[0]);
        else enemyTurn(currentFighters[0]);
    }

    // Update is called once per frame
    void Update() {
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

    private void updateSelected(Battler currentFighter)
    {
        GameObject.Find("Canvas/Bottom/Character/Avatar").GetComponent<Image>().sprite = currentFighter.entity.sprite;
        GameObject.Find("Canvas/Bottom/Character/Name").GetComponent<Text>().text = currentFighter.entity.title;
        GameObject.Find("Canvas/Bottom/Character/Name").GetComponent<Text>().color = currentFighter.entity.color;
    }

    private void playerTurn(Battler battler)
    {
        showChoices(battler);

    }

    private void showChoices(Battler currentFighter)
    {
        dialogueLayout.SetActive(false);
        fightLayout.SetActive(true);
        fightLayout.transform.Find("Buttons/Melee").GetComponent<Toggle>().interactable = true;
        if(currentFighter.entity.spells != null && currentFighter.entity.spells.Count != 0) fightLayout.transform.Find("Buttons/Spells").GetComponent<Toggle>().interactable = true;
        else fightLayout.transform.Find("Buttons/Spells").GetComponent<Toggle>().interactable = false;
        if (currentFighter.entity.items != null && currentFighter.entity.items.Count != 0) fightLayout.transform.Find("Buttons/Items").GetComponent<Toggle>().interactable = true;
        else fightLayout.transform.Find("Buttons/Items").GetComponent<Toggle>().interactable = false;
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

    public void clicked(Battler battler)
    {
        if (battler == null) return;
        if (melee.isOn)
        {
            attack(currentFighters[0].entity, battler);
        }
        else if (spells.isOn)
        {

        }
        else if (items.isOn)
        {

        }
    }

    public void attack(Entity attacker, Battler defender)
    {
        int damage = attacker.stats.attack.getCurrent();
        damage = (int)(damage * (defender.entity.stats.defense.getCurrent() / 100));
        defender.entity.stats.health.add(-damage);
        if (defender.entity.stats.health.getCurrent() <= 0)
        {
            death(defender);
        }
        defender.updateHealthbar();
    }

    public void death(Battler dying)
    {

    }
}