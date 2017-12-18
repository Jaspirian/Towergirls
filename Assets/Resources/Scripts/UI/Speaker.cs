using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speaker : MonoBehaviour {

    public Image avatar;
    public Text title;

    private Entity currentEntity;

    public Speaker()
    {

    }

    public void SetEntity(Entity entity)
    {
        currentEntity = entity;
        avatar.sprite = entity.sprite;
        title.text = entity.title;
        title.color = entity.color;
    }

    public Entity getEntity()
    {
        return currentEntity;
    }

}
