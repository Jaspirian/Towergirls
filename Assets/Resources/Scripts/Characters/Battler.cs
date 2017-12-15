using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler {

    public Entity entity;
    public Vector3 location;

    public GameObject battleSprite;
    public GameObject healthBar;
    public GameObject battleBase;

	public Battler(Entity entity, Vector3 location)
    {
        this.entity = entity;
        this.location = location;

        string folderLoc = "/Battle/Bases/" + location.x + "/" + location.y + "/" + location.z + "/";
        battleSprite = GameObject.Find(folderLoc + "BattleSprite");
        healthBar = GameObject.Find(folderLoc + "Healthbar");
        battleBase = GameObject.Find(folderLoc + "Base");
    }

    public void show()
    {
        battleSprite.SetActive(true);
        battleSprite.GetComponent<SpriteRenderer>().sprite = entity.sprite;
        healthBar.SetActive(true);
    }
}
