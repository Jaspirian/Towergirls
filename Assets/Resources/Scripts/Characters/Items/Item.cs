using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item  {

    public string title;
    public string description;
    public Sprite sprite;

    public Item(string title, string description)
    {
        this.title = title;
        this.description = description;

        sprite = Resources.Load(title) as Sprite;
    }

}
