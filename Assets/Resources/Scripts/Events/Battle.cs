using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {

    private const int NUM_DISPLAYED = 6;
    private List<Entity> order;

    private Dictionary<int[], Entity> initialFighters;
    private Dictionary<int[], Entity> currentFighters;

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
        order = getOrder(currentFighters);
        displayHeads(order);
    }

    // Update is called once per frame
    void Update() {

        if (currentState == BattleStates.START)
        {
            if (order[0].isPlayerControlled) {
                currentState = BattleStates.PLAYERCHOICE;
            } else {
                currentState = BattleStates.ENEMYCHOICE;
            }
        } else if (currentState == BattleStates.PLAYERCHOICE)
        {
            showOptions(order[0]);
        } else if (currentState == BattleStates.ENEMYCHOICE)
        {
            enemyTurn(order[0]);
        } else if (currentState == BattleStates.WIN)
        {
            playWin();
        } else
        {
            playLoss();
        }

        displaySprites(currentFighters);
    }

    private Dictionary<int[], Entity> getFighters()
    {
        Dictionary<int[], Entity> temp = new Dictionary<int[], Entity>();
        //THIS IS PLACEHOLDER STUFF
        temp.add(new int[] { 0, 1, 1 }, new entity("sir knight", null, true, new stats(150, 6, 2, 3, 1, 1)));
        temp.add(new int[] { 1, 0, 0 }, new entity("bandit male", null, false, new stats(100, 4, 1, 2, 0, 1)));
        temp.add(new int[] { 1, 1, 1 }, new entity("bandit spike", null, false, new stats(100, 4, 1, 2, 0, 1)));
        temp.add(new int[] { 1, 0, 2 }, new entity("bandit female", null, false, new stats(100, 4, 1, 2, 0, 1)));
        //
        return temp;
    }

    private List<Entity> getOrder(Dictionary<int[], Entity> fighters)
    {
        List<Entity> unordered = new List<Entity>();
        List<Entity> orderedBySpeed = new List<Entity>();
        foreach (KeyValuePair<int[], Entity> entry in fighters)
        {
            unordered.Add(entry.Value);
        }

        //sort them
        int length = unordered.Count;
        for(int i=0; i<length; i++)
        {
            Entity fastest = null;
            for(int j=0; j<unordered.Count; j++)
            {
                if (fastest == null || unordered[j].stats.speed.getChangedVal() > fastest.stats.speed.getChangedVal()) fastest = unordered[j];
            }
            orderedBySpeed.Add(fastest);
            unordered.Remove(fastest);
        }

        return orderedBySpeed;
    }

    private void displayHeads(List<Entity> order)
    {
        int j = 0;
        for(int i=0; i<NUM_DISPLAYED; i++)
        {
            GameObject head = GameObject.Find("/Battle/Turn order/" + (i + 1));
            //Debug.Log(head);
            Sprite sprite = null;
            if (j >= order.Count) j = 0;
            //Debug.Log(j);
            sprite = order[j].getSprite();
            //Debug.Log(sprite);
            head.GetComponent<SpriteRenderer>().sprite = sprite;
            j++;
        }
    }

    private void displaySprites(Dictionary<int[], Entity> fighters)
    {
        for(int side = 0; side < 2; side++)
        {
            for(int column = 0; column < 2; column++)
            {
                for(int row = 0; row < 3; row++)
                {
                    foreach (KeyValuePair<int[], Entity> entry in fighters)
                    {
                        if(entry.Key[0] == side && entry.Key[1] == column && entry.Key[2] == row)
                        {
                            string folderLoc = "/Battle/Bases/" + side + "/" + column + "/" + row + "/";
                            GameObject sprite = GameObject.Find(folderLoc + "BattleSprite");
                            sprite.GetComponent<SpriteRenderer>().sprite = entry.Value.getSprite();
                            sprite.GetComponent<SpriteRenderer>().enabled = true;
                            GameObject healthBar = GameObject.Find(folderLoc + "Healthbar");
                            healthBar.GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                }
            }
        }
    }

    private void showOptions(Entity currentFighter)
    {

    }

    private void enemyTurn(Entity currentFighter)
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
        Entity justWent = order[0];
        order.RemoveAt(0);
        order.Add(justWent);

        displayHeads(order);
    }
}