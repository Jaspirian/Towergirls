using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity {

    public string title;
    public Color color;
    public Sprite sprite;
    public bool isPlayerControlled;

    public Stats stats;

	public Entity(string title, bool isPlayerControlled)
    {
        sprite = Resources.Load<Sprite>("Sprites/Characters/" + title);

        this.title = title;
        this.isPlayerControlled = isPlayerControlled;
    }
}
