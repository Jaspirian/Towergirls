using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baseClick : MonoBehaviour {

    private GameObject battleBase;
    public Battler battler;
    private Battle battle;

    // Use this for initialization
    void Start () {
        battle = GameObject.Find("Battle").GetComponent<Battle>();
        battleBase = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onMouseUpAsButton()
    {
        battle.clicked(battler);
    }
}
