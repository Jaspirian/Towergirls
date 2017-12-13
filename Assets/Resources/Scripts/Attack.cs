using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack {

    public string title;
    public string description;
    public Shape shape;
    public string statName;
    public double modifier;
    public int baseDamage;

    public Attack(string title, string description, Shape shape, string statName, double modifier, int baseDamage)
    {
        this.title = title;
        this.description = description;
        this.shape = shape;
        this.statName = statName;
        this.modifier = modifier;
        this.baseDamage = baseDamage;
    }

    public int getDamage(Entity attacker)
    {
        int damage = 0;

        damage = baseDamage;
        Statval stat = null;
        if (statName == "love") stat = attacker.stats.love;
        if (statName == "lust") stat = attacker.stats.lust;
        if (statName == "wealth") stat = attacker.stats.wealth;
        if (statName == "power") stat = attacker.stats.power;
        if (stat != null)
        {
            damage += (int)(attacker.stats.love.getChangedVal() * modifier);
        }
        return damage;
    }
}
