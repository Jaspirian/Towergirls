using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSprite : MonoBehaviour {

    private Entity entity;
    private CharacterBase characterBase;
    private HealthBar healthBar;

    public BattleSprite(Entity entity) {
        this.entity = entity;
        characterBase = new CharacterBase(entity);
        healthBar = new HealthBar(entity);
    }

	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
	}
}
