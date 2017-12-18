using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightButton : MonoBehaviour {
    
    private Cells cells;

	// Use this for initialization
	void Start () {
        cells = GameObject.Find("Canvas/Battle/Cells").GetComponent<Cells>();
        gameObject.GetComponent<Toggle>().onValueChanged.AddListener(click);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void click(bool currentState)
    {
        cells.setClickable(currentState);
    }
}
