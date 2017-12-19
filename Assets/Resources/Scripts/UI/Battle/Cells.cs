using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Cells : MonoBehaviour {

    public Dictionary<Vector3, Cell> cells;

	// Use this for initialization
	void Start () {
        cells = new Dictionary<Vector3, Cell>();
        for (int side = 0; side < 2; side++) 
        {
            for (int column = 0; column < 2; column++) 
            {
                for (int row = 0; row < 3; row++) 
                {
                    string fileLocation = "/Canvas/Battle/Cells/" + side + "/" + column + "/" + row + "/";
                    Cell cell = GameObject.Find(fileLocation).GetComponent<Cell>();
                    Vector3 cellLocation = new Vector3(side, column, row);
                    cells.Add(cellLocation, cell);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetClickable(bool clickable)
    {
        foreach (KeyValuePair<Vector3, Cell> entry in cells)
        {
            entry.Value.SetClickable(clickable);
        }
    }

    public void SetVisible(bool visible)
    {
        foreach (KeyValuePair<Vector3, Cell> entry in cells)
        {
            entry.Value.SetVisible(visible);
        }
    }
}
