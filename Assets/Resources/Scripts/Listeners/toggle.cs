using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle : MonoBehaviour {

    public Toggle button;
    public Color defaultColor;
    public Color defaultHighlight;
    public Color defaultPressed;
    public Color selectedColor;
    public Color selectedHighlight;
    public Color selectedPressed;

	// Use this for initialization
	void Start () {
        button.onValueChanged.AddListener(toggleListener);
        ColorBlock cb = button.colors;
        cb.normalColor = defaultColor;
        cb.highlightedColor = defaultHighlight;
        cb.pressedColor = selectedPressed;
        button.colors = cb;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void toggleListener(bool isOn)
    {
        ColorBlock cb = button.colors;
        if(isOn)
        {
            cb.normalColor = selectedColor;
            cb.highlightedColor = selectedHighlight;
            cb.pressedColor = defaultPressed;
        }
        else
        {
            cb.normalColor = defaultColor;
            cb.highlightedColor = defaultHighlight;
            cb.pressedColor = selectedPressed;
        }
        button.colors = cb;
    }
}
