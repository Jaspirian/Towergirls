using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                    string location = "/Canvas/Battle/Cells/" + side + "/" + column + "/" + row + "/";
                    cells.Add(new Vector3(side, column, row), GameObject.Find(location).GetComponent<Cell>());
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
            cells[battler.location].SetActive(true);
            cells[battler.location].SetEntity(battler.entity);
        }
    }
}
