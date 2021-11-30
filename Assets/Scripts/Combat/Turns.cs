using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    int ActionPoint = 3;

    public void ActionEconomy()
    {
        ActionPoint--;

        Debug.Log(ActionPoint);

        if(ActionPoint <= 0)
        {
            ActionPoint = 3;
            GameObject.Find("Enemy").GetComponent<EnemyAI>().OnTurnChange_DoEnemyAttack();
        }

    }


}
