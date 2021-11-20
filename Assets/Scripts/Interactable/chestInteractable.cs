using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestInteractable : Interactable
{
    override public void  Interact(GameObject InteractingObject)
    {
        Debug.Log("The chest was opened");
        //Chest Sprite change
    }
}
