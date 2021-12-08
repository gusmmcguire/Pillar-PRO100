using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turns : MonoBehaviour
{
    int ActionPoint = 3;
    public bool shouldGameEnd;
    public bool winLose;

    private void Update()
    {
        if (shouldGameEnd) CombatEnd();
    }

    public void ActionEconomy()
    {
        BattleInteractions.DisableAPUI(--ActionPoint);

        if(ActionPoint <= 0)
        {
            ActionPoint = 3;
            BattleInteractions.EnableAllAPUI();

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyAI>().OnTurnChange_DoEnemyAttack();
            }
        }

    }

    public void CombatEnd()
    {
        shouldGameEnd = false;
        //if player wins
        if(winLose) StartCoroutine(BattleInteractions.GameWin());
        //if player loses
        else StartCoroutine(BattleInteractions.GameOver());
    }


}
