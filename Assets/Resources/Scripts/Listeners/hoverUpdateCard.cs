using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverUpdateCard : MonoBehaviour {

    public Card card;
    public Entity entity;
    public Entity selectedEntity;

    public hoverUpdateCard(Card card, Entity entity)
    {
        this.card = card;
        this.entity = entity;
    }

    public void setSelected(Entity selected)
    {
        selectedEntity = selected;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter()
    {
        card.updateCard(entity);
    }

    private void OnMouseExit()
    {
        card.Reset();
    }
}
