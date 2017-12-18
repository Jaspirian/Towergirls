using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    public Entity selected;

    public Image avatar;
    public Text kingdom;
    public Text title;
    public Text attributes;
    public Text[] itemTexts;
    public Image[] itemImages;
    public Text[] preferenceTexts;
    public Image[] preferenceImages;
    public Text description;

	public Card()
    {

    }

    public void SetSelected(Entity e)
    {
        selected = e;
        UpdateCard(e);
    }

    public void TempShow(Entity e)
    {
        UpdateCard(e);
    }

    public void Reset()
    {
        UpdateCard(selected);
    }

    public void UpdateCard(Entity e)
    {
        if (e == null) return;

        avatar.sprite = e.sprite;
        kingdom.text = e.kingdom;
        kingdom.color = e.color;
        title.text = e.title;
        title.color = e.color;
        
        string attributesNew = "";
        if (e.attributes != null)
        {
            attributes.enabled = true;
            foreach (Judgment attr in e.attributes)
            {
                if (attributesNew != "") attributesNew += "\n";
                if (attr.isPositive) attributesNew += "+";
                else attributesNew += "-";
                attributesNew += " ";
                attributesNew += attr.description;
            }
            attributes.text = attributesNew;
        }
        else
        {
            attributes.enabled = false;
        }
        
        for (int i = 0; i < 3; i++)
        {
            if (e.items != null && i < e.items.Count)
            {
                itemImages[i].enabled = true;
                itemTexts[i].enabled = true;
                itemImages[i].sprite = e.items[i].sprite;
                itemTexts[i].text = e.items[i].description;
            }
            else
            {
                itemImages[i].enabled = false;
                itemTexts[i].enabled = false;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (e.preferences != null && i < e.preferences.Count)
            {
                preferenceImages[i].enabled = true;
                preferenceTexts[i].enabled = true;
                if (e.preferences[i].isPositive) preferenceImages[i].sprite = Resources.Load("Sprites/Shapes/Heart") as Sprite;
                else preferenceImages[i].sprite = Resources.Load("Sprites/Shapes/Broken heart") as Sprite;
                preferenceTexts[i].text = e.preferences[i].description;
            }
            else
            {
                preferenceImages[i].enabled = false;
                preferenceTexts[i].enabled = false;
            }
        }
        description.text = "\"" + e.description + "\"";
        description.color = e.color;

    }
}
