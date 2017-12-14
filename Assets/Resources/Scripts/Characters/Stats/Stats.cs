using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public Stat health;
    public Stat speed;

    public Stat love;
    public Stat lust;
    public Stat wealth;
    public Stat power;

    public Stat attack;
    public Stat defense;

    public Stats(int health, int speed, int love, int lust, int wealth, int power, int attack, int defense)
    {
        this.health = new Stat(health);
        this.speed = new Stat(speed);

        this.love = new Stat(love);
        this.lust = new Stat(lust);
        this.wealth = new Stat(wealth);
        this.power = new Stat(power);

        this.attack = new Stat(attack);
        this.defense = new Stat(defense);
    }

}
