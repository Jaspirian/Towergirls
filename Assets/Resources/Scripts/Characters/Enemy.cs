using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    public Enemy(string title, bool isPlayerControlled) : base(title, isPlayerControlled)
    {
        TextAsset csv = Resources.Load("Spreadsheets/Enemies") as TextAsset;
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
        description = cells[3];
        //3
        mainStat = cells[4];
        //4
        stats = new Stats(int.Parse(cells[9]), int.Parse(cells[10]), int.Parse(cells[5]), int.Parse(cells[6]), int.Parse(cells[7]), int.Parse(cells[8]), int.Parse(cells[11]), int.Parse(cells[12]));
        //12
    }
}
