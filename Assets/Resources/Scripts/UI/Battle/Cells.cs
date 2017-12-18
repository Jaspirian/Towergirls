using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cells : MonoBehaviour {

    public Dictionary<Vector3, Cell> cells;
    public Battle battle;

	// Use this for initialization
	void Start () {
        battle = GameObject.Find("Canvas/Battle").GetComponent<Battle>();
        cells = new Dictionary<Vector3, Cell>();
        for (int side = 0; side < 2; side++) 
        {
            for (int column = 0; column < 2; column++) 
            {
                for (int row = 0; row < 3; row++) 
                {
                    string location = "/Canvas/Battle/Cells/" + side + "/" + column + "/" + row + "/";
                    Cell cell = GameObject.Find(location).GetComponent<Cell>();
                    cell.location = new Vector3(side, column, row);
                    cell.battle = battle;
                    cells.Add(cell.location, cell);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowSprites(List<Battler> battlers)
    {
        foreach (KeyValuePair<Vector3, Cell> entry in cells)
        {
            entry.Value.SetActive(false);
        }
        foreach (Battler battler in battlers)
        {
            Cell cell = cells[battler.location];
            cell.SetActive(true);
            cell.SetEntity(battler.entity);
        }
    }

    public void SetSelected(Battler battler, bool selected)
    {
        cells[battler.location].SetSelected(selected);
    }

    public void setClickable(bool clickable)
    {
        foreach (KeyValuePair<Vector3, Cell> entry in cells)
        {
            entry.Value.SetClickable(clickable);
        }
    }
}
