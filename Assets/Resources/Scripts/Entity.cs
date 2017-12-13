using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity {

    public string title;
    public string image;

    public bool isPlayerControlled;

    public Stats stats;

    public Entity(string title, string image, bool isPlayerControlled, Stats stats)
    {
        this.title = title;
        this.image = image;
        if (image == null) this.image = this.title;
        this.isPlayerControlled = isPlayerControlled;
        this.stats = stats;
    }

    public Sprite getSprite()
    {
        string FOLDERLOCATION = "Sprites/Characters/";
        string name = title;
        if (image != null) name = image;
        //Debug.Log(FOLDERLOCATION + name);
        Sprite sprite = Resources.Load<Sprite>(FOLDERLOCATION + name);
        //Debug.Log(sprite);
        return sprite;
    }
}
