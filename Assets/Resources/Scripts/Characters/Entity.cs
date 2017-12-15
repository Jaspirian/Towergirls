using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity {

    public string title;
    public bool isPlayerControlled;

    public Color color = Color.black;
    public Sprite sprite;
    public string kingdom = "";
    public Judgment[] attributes;
    public string mainStat;
    public Item[] items;
    public Spell[] spells;
    public Judgment[] preferences;
    public string description = "";

    public Stats stats;

	public Entity(string title, bool isPlayerControlled)
    {
        sprite = Resources.Load<Sprite>("Sprites/Characters/" + title);

        this.title = title;
        this.isPlayerControlled = isPlayerControlled;
    }
}
