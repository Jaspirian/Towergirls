using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battler {

    public Entity entity;
    public Vector3 location;
    
    public Cell cell;

	public Battler(Entity entity, Vector3 location, Cell cell)
    {
        this.entity = entity;
        this.location = location;
        this.cell = cell;

        cell.SetEntity(entity);
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

    public void SetVisible(bool visible)
    {
        cell.SetVisible(visible);
    }

    public void SetSelected(bool selected)
    {
        cell.SetSelected(selected);
    }

    public bool ChangeHealth(int addition)
    {
        entity.stats.health.add(addition);
        float percentHealth = (float)entity.stats.health.getCurrent() / (float)entity.stats.health.initialValue;
        cell.UpdateHealthBar(percentHealth);
        if (entity.stats.health.getCurrent() <= 0) return true;
        return false;
    }

    public void Die(Battler killer)
    {

    }

    public void Click()
    {
        cell.cellBase.GetComponent<Button>().onClick.Invoke();
    }
}
