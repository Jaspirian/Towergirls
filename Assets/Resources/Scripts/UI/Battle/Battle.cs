using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    private const int NUM_DISPLAYED = 6;

    private List<Battler> initialFighters;
    private List<Battler> currentFighters;

    public EventSystem eventSystem;

    private Card card;
    private Order order;
    private Cells cells;
    public GameObject dialogueLayout;
    public GameObject fightLayout;

    public Toggle melee;
    public Toggle spells;
    public Toggle items;

    public Speaker speaker;

    // Use this for initialization
    void Start() {
        card = GameObject.Find("Canvas/Right/Card").GetComponent<Card>();
        order = GameObject.Find("Canvas/Battle/Order").GetComponent<Order>();
        cells = GameObject.Find("Canvas/Battle/Cells").GetComponent<Cells>();
        speaker = GameObject.Find("Canvas/Bottom/Speaker").GetComponent<Speaker>();
        
        initialFighters = getFighters();
        currentFighters = getFighters();
        foreach (Battler battler in currentFighters)
        {
            battler.cell.cellBase.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Target(battler);
            });
        }
        currentFighters = currentFighters[0].SortBySpeed(currentFighters);

        order.SetOrder(currentFighters);

        cells.SetVisible(false);
        foreach (Battler battler in currentFighters)
        {
            battler.SetVisible(true);
        }

        NextTurn(false);
    }

    // Update is called once per frame
    void Update() {

    }

    private List<Battler> getFighters()
    {
        List<Battler> temp = new List<Battler>();
        //THIS IS PLACEHOLDER STUFF
        temp.Add(new Battler(new Knight("Sir Knight", true), new Vector3(0, 1, 1), cells.cells[new Vector3(0, 1, 1)]));
        temp.Add(new Battler(new Enemy("Bandit Male", false), new Vector3(1, 0, 0), cells.cells[new Vector3(1, 0, 0)]));
        temp.Add(new Battler(new Enemy("Bandit Spike", false), new Vector3(1, 1, 1), cells.cells[new Vector3(1, 1, 1)]));
        temp.Add(new Battler(new Enemy("Bandit Female", false), new Vector3(1, 0, 2), cells.cells[new Vector3(1, 0, 2)]));
        //
        return temp;
    }

    private void PlayerTurn(Battler battler)
    {
        eventSystem.enabled = true;
    }

    private void ShowChoices(Battler currentFighter)
    {
        dialogueLayout.SetActive(false);
        fightLayout.SetActive(true);
        fightLayout.transform.Find("Buttons/Melee").GetComponent<Toggle>().interactable = true;
        if(currentFighter.entity.spells != null && currentFighter.entity.spells.Count != 0) fightLayout.transform.Find("Buttons/Spells").GetComponent<Toggle>().interactable = true;
        else fightLayout.transform.Find("Buttons/Spells").GetComponent<Toggle>().interactable = false;
        if (currentFighter.entity.items != null && currentFighter.entity.items.Count != 0) fightLayout.transform.Find("Buttons/Items").GetComponent<Toggle>().interactable = true;
        else fightLayout.transform.Find("Buttons/Items").GetComponent<Toggle>().interactable = false;
    }

    private IEnumerator EnemyTurn(Battler currentFighter)
    {
        eventSystem.enabled = false;
        yield return new WaitForSeconds(2);
        melee.GetComponent<Toggle>().isOn = true;
        yield return new WaitForSeconds(2);
        List<Battler> options = new List<Battler>();
        foreach (Battler battler in currentFighters) if (battler.entity.isPlayerControlled) options.Add(battler);
        Battler target = options[Random.Range(0, options.Count - 1)];
        target.Click();
    }

    private void Win()
    {

    }

    private void Lose()
    {

    }


    private void NextTurn(bool increment)
    {
        melee.isOn = false;
        spells.isOn = false;
        items.isOn = false;
        cells.ClearHighlight();

        if (increment)
        {
            Battler justWent = currentFighters[0];
            currentFighters.RemoveAt(0);
            currentFighters.Add(justWent);
            justWent.SetSelected(false);
            order.SetOrder(currentFighters);
        }

        Debug.Log(currentFighters[0].entity.title + "'s turn.");

        currentFighters[0].SetSelected(true);

        speaker.SetEntity(currentFighters[0].entity);

        card.SetSelected(currentFighters[0].entity);

        ShowChoices(currentFighters[0]);

        if (currentFighters[0].entity.isPlayerControlled)
        {
            PlayerTurn(currentFighters[0]);
        }
        else
        {
            StartCoroutine(EnemyTurn(currentFighters[0]));
        }
    }

    public void Target(Battler targeted)
    {
        if (melee.isOn)
        {
            if (targeted.entity != null)
            {
                Attack(currentFighters[0], targeted);
            }
        }
        else if (spells.isOn)
        {

        }
        else if (items.isOn) 
        {

        }
    }

    public void Attack(Battler attacker, Battler defender)
    {
        int damage = attacker.entity.stats.attack.getCurrent();
        int defense = defender.entity.stats.defense.getCurrent();
        float defensePercent = (float)defense / 100;
        damage = (int)(damage * (1 - defensePercent));
        if (defender.ChangeHealth(-damage))
        {
            Death(defender, attacker);
        }
        else
        {
            NextTurn(true);
        }
    }

    public void Death(Battler dying, Battler killer)
    {
        dying.Die(killer);
        currentFighters.Remove(dying);
        int controlled = 0;
        int uncontrolled = 0;
        foreach (Battler battler in currentFighters)
        {
            if (battler.entity.isPlayerControlled) controlled++;
            if (!battler.entity.isPlayerControlled) uncontrolled++;
        }
        if (controlled == 0) Lose();
        if (uncontrolled == 0) Win();
    }
}