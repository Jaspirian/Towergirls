using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverColor : MonoBehaviour {

    public Color normalColor;
    public Color changeColor;
    private SpriteRenderer mesher;

	// Use this for initialization
	void Start () {
        mesher = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        mesher.material.color = changeColor;
    }

    void OnMouseExit()
    {
        mesher.material.color = normalColor;
    }
}
