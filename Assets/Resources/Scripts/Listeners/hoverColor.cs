using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoverColor : MonoBehaviour {

    public Color normalColor;
    public Color changeColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        Debug.Log("hi");
        GetComponent<Image>().color = changeColor;
    }

    void OnMouseExit()
    {
        GetComponent<Image>().color = normalColor;
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("clicked");
    }
}
