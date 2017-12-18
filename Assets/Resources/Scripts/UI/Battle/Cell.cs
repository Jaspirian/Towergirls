using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour {

    public Entity entity;

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

    public void SetActive(bool visible)
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

    public void SetEntity(Entity entity)
    {
        this.entity = entity;
        cellBase.GetComponent<CellBase>().entity = entity;
        cellSprite.GetComponent<Image>().sprite = entity.sprite;
    }

    public void ChangeHealthBar(float percent)
    {
        Rect rect = greenHealth.GetComponent<RectTransform>().rect;
        float height = rect.height;
        height *= percent;
        rect.Set(rect.x, rect.y, rect.width, height); //hack fix
    }

    public void SetClickable(bool clickable)
    {
        cellBase.GetComponent<Button>().interactable = clickable;
    }
}
