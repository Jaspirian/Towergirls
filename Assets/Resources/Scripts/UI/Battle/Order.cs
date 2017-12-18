using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour {

    public Image[] images;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetOrder(List<Battler> order)
    {
        int j = 0;
        for (int i=0; i<images.Length; i++, j++)
        {
            if (j >= order.Count) j = 0;
            images[i].sprite = order[j].entity.sprite;
        }
    }
}
