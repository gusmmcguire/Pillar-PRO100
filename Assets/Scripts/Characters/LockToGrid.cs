using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToGrid : MonoBehaviour
{
    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        //if the gameObject is not on the grid
        //gets the transform object off of the gameObject we are on
        //and sets the position to a rounded position
        //this is to ensure that we are never off our grid
        if (gameObject.GetComponent<SelectorCombat>() && gameObject.GetComponent<SelectorCombat>().mouseHasControl) return;
        if(gameObject.GetComponent<Transform>().position.x % 1 != 0 || gameObject.GetComponent<Transform>().position.y % 1 != 0)
        gameObject.GetComponent<Transform>().position = new Vector3(Mathf.Round(gameObject.GetComponent<Transform>().position.x), Mathf.Round(gameObject.GetComponent<Transform>().position.y), gameObject.GetComponent<Transform>().position.z);
    }
}
