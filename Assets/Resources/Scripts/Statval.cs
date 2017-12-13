using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statval {

    public int startingVal;

    public int added;
    public double modded;

    public Statval(int val)
    {
        startingVal = val;
        added = 0;
        modded = 0;
    }

    public double addMod(double mod)
    {
        modded *= mod;
        return modded;
    }

    public int addBy(int add)
    {
        added += add;
        return added;
    }

    public int getChangedVal()
    {
        int val = startingVal;
        if(added != 0) val += added;
        if(modded != 0) val = (int)(val * modded);
        return val;
    }

    public void clear()
    {
        added = 0;
        modded = 0;
    }
}
