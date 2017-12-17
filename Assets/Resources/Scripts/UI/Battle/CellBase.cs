using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellBase : MonoBehaviour, IPointerEnterHandler {
    public Entity entity;
    private Card card;

	// Use this for initialization
	void Start () {
        card = GameObject.Find("Canvas/Right/Card").GetComponent<Card>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        card.UpdateCard(entity);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        card.Reset();
    }
}
