using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    int ActionPoint = 0;

    public void ActionEconomy()
    {
        ActionPoint = 3;

        //IF Combat is called
        //{
        ActionPoint -= ActionPoint;
        //}

        //IF Movement is called
        //{
        ActionPoint -= ActionPoint;
        //}

        //IF Special Action is taken (Magic, items, etc)
        //{
        ActionPoint -= ActionPoint;
        //}

        //Free actons?

        if(ActionPoint <= 0)
        {
            //Call EnemyAI
            return;
        }

    }


}
