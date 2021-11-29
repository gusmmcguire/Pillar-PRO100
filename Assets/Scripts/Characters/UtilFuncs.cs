using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UtilFuncs : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 CheckDistance(Transform objectTransform)
    {
        float x = Math.Abs(objectTransform.position.x - gameObject.transform.position.x);
        float y = Math.Abs(objectTransform.position.y - gameObject.transform.position.y);
        return new Vector2(x, y);
    }
}
