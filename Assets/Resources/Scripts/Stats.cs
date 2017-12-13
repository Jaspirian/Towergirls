using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public Statval health;
    public Statval speed;

    public Statval love;
    public Statval lust;
    public Statval wealth;
    public Statval power;

    public Stats(int health, int speed, int love, int lust, int wealth, int power)
    {
        this.health = new Statval(health);
        this.speed = new Statval(speed);
        this.love = new Statval(love);
        this.lust = new Statval(lust);
        this.wealth = new Statval(wealth);
        this.power = new Statval(power);
    }
}
