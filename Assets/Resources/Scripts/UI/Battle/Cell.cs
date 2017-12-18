using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour {

    public GameObject bottoms;

    public GameObject cellBase;

    public GameObject healthBar;
    public GameObject redHealth;
    public GameObject greenHealth;

    public GameObject cellSprite;

    public GameObject triangle;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetEntity(Entity e)
    {
        cellSprite.GetComponent<Image>().sprite = e.sprite;
        //something with health
    }

    public void SetVisible(bool visible)
    {
        healthBar.SetActive(visible);
        cellSprite.SetActive(visible);
        if(!visible) SetClickable(false);
        cellBase.GetComponent<CellBase>().enabled = visible;
    }

    public void SetSelected(bool selected)
    {
        triangle.SetActive(selected);
    }

    public void SetClickable(bool clickable)
    {
        cellBase.GetComponent<Button>().interactable = clickable;
    }

    public void UpdateHealthBar(float percentHealth)
    {
        Debug.Log("DAMAGED to " + percentHealth);
        //Rect green = greenHealth.transform.GetComponent<RectTransform>().rect;
        Rect container = healthBar.transform.GetComponent<RectTransform>().rect;
        //green.Set(green.x, container.height * (1 - percentHealth), green.width, green.height);
        //Debug.Log(green.x + "," + green.y + "," + green.width + "," + green.height);
        greenHealth.GetComponent<RectTransform>().offsetMax = new Vector2(greenHealth.GetComponent<RectTransform>().offsetMax.x, -(container.height * (1 - percentHealth)));
    }
}
