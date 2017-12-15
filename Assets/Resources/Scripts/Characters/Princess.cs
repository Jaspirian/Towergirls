using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : Entity {
    
    public string kingdom;
    public Judgment[] proCons;
    public string mainStat;
    public Item[] items;
    public Spell[] spells;
    public Judgment[] likes;
    public string description;

	public Princess(string title, bool isPlayerControlled) : base(title, isPlayerControlled)
    {
        readFile();
    }

    public void readFile()
    {
        TextAsset csv = Resources.Load("Spreadsheets/Princesses") as TextAsset;
        char[] returns = new char[] { '\r', '\n' };
        string[] lines = csv.text.Split(returns);
        string rightLine = "";
        foreach (string line in lines)
        {
            if (line.Substring(0, title.Length - 1) == title)
            {
                rightLine = line;
                break;
            }
        }

        string[] cells = rightLine.Split('\t');

        //0
        color = new Color(int.Parse(cells[1].Split(',')[0]), int.Parse(cells[1].Split(',')[1]), int.Parse(cells[1].Split(',')[2]));
        //1
        kingdom = cells[2];
        //2
        proCons = new Judgment[5];
        for (int i = 0; i < proCons.Length; i++)
        {
            proCons[i] = new Judgment(bool.Parse(cells[3 + (i * 2)]), cells[4 + (i * 2)]);

        }
        //12
        items = new Item[3];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new Item(cells[13 + (i * 2)], cells[14 + (i * 2)]);
        }
        //16
        likes = new Judgment[3];
        for (int i = 0; i < likes.Length; i++)
        {
            likes[i] = new Judgment(bool.Parse(cells[17 + (i * 2)]), cells[18 + (i * 2)]);
        }
        //22
        description = cells[23];
        //23
        mainStat = cells[24];
        //24
        stats = new Stats(int.Parse(cells[29]), int.Parse(cells[30]), int.Parse(cells[25]), int.Parse(cells[26]), int.Parse(cells[27]), int.Parse(cells[28]), int.Parse(cells[31]), int.Parse(cells[32]));
        //32
    }

}
