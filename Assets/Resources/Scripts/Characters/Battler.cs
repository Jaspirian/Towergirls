using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battler {

    public Entity entity;
    public Vector3 location;

	public Battler(Entity entity, Vector3 location)
    {
        this.entity = entity;
        this.location = location;
    }

    public List<Battler> SortBySpeed(List<Battler> list)
    {
        list.Sort(delegate (Battler a, Battler b)
        {
            int speedA = a.entity.stats.speed.getCurrent();
            int speedB = b.entity.stats.speed.getCurrent();
            if (speedA > speedB) return -1;
            if (speedA < speedB) return 1;
            return 0;
        });

        return list;
    }

    public void Die(Entity killer)
    {

    }
}
