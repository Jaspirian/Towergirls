using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity {

    public string title;
    public Sprite sprite;
    public bool isPlayerControlled;

	public Entity(string title, bool isPlayerControlled)
    {
        this.title = title;
        this.isPlayerControlled = isPlayerControlled;
    }
}
