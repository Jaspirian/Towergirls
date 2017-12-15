using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat {

    public int initialValue;

    public int added;
    public double modded;

	public Stat(int initialValue)
    {
        this.initialValue = initialValue;
    }

    public void add(int amount)
    {
        added += amount;
    }

    public void mod(double amount)
    {
        modded *= amount;
    }

    public int getCurrent()
    {
        int val = initialValue;
        val += added;
        if(modded != 0) val = (int)(val * modded);
        return val;
    }
}
