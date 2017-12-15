using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Entity {

    public Knight(string title, bool isPlayerControlled) : base(title, isPlayerControlled)
    {
        TextAsset csv = Resources.Load("Spreadsheets/Knights") as TextAsset;
        char[] returns = new char[] { '\r', '\n' };
        string[] lines = csv.text.Split(returns);
        string rightLine = "";
        foreach (string line in lines)
        {
            if (line.Length >= title.Length && line.Substring(0, title.Length) == title)
            {
                rightLine = line;
                break;
            }
        }

        string[] cells = rightLine.Split('\t');

        //0
        color = new Color(float.Parse(cells[1].Split(',')[0]) / 255, float.Parse(cells[1].Split(',')[1]) / 255, float.Parse(cells[1].Split(',')[2]) / 255);
        //1
        kingdom = cells[2];
        //2
        attributes = new Judgment[5];
        for (int i = 0; i < attributes.Length; i++)
        {
            if (string.IsNullOrEmpty(cells[3 + (i * 2)])) break;
            attributes[i] = new Judgment(bool.Parse(cells[3 + (i * 2)]), cells[4 + (i * 2)]);

        }
        //12
        items = new Item[3];
        for (int i = 0; i < items.Length; i++)
        {
            if (string.IsNullOrEmpty(cells[13 + (i * 2)])) break;
            items[i] = new Item(cells[13 + (i * 2)], cells[14 + (i * 2)]);
        }
        //18
        preferences = new Judgment[3];
        for (int i = 0; i < preferences.Length; i++)
        {
            if (string.IsNullOrEmpty(cells[19 + (i * 2)])) break;
            preferences[i] = new Judgment(bool.Parse(cells[19 + (i * 2)]), cells[20 + (i * 2)]);
        }
        //24
        description = cells[25];
        //25
        mainStat = cells[26];
        //26
        stats = new Stats(int.Parse(cells[31]), int.Parse(cells[32]), int.Parse(cells[27]), int.Parse(cells[28]), int.Parse(cells[29]), int.Parse(cells[30]), int.Parse(cells[33]), int.Parse(cells[34]));
        //34
    }

}
