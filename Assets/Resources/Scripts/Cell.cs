using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell {

    public int[] location;
    private Entity entity;
    private CharacterBase characterBase;
    private HealthBar healthBar;
    private BattleSprite battleSprite;

    public Cell(int[] location, Entity entity) {
        this.location = new int[] { location[0], location[1] };
        this.entity = entity;
    }
}
