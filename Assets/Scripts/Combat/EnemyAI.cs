using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public void OnTurnChange_DoEnemyAttack(){
        StartCoroutine(OnLogic_FindLocation());
	}
    IEnumerator OnLogic_FindLocation()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject player = GameObject.Find("Player");
        Statable statable = gameObject.GetComponent<Statable>();
        if (gameObject.GetComponent<UtilFuncs>().CheckDistance(player.transform).magnitude < statable.GetCharaMoveRange())
        {
            Vector3 prevPosition = gameObject.transform.position;
            gameObject.transform.position = player.transform.position;

            bool shouldBeHorizontal = Mathf.Abs(gameObject.transform.position.x - prevPosition.x) > Mathf.Abs(gameObject.transform.position.y - prevPosition.y);
            bool below = gameObject.transform.position.y - prevPosition.y > 0;
            bool left = gameObject.transform.position.x - prevPosition.x > 0;

            if (shouldBeHorizontal) gameObject.transform.position = new Vector3(left ? gameObject.transform.position.x - 1 : gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
            else gameObject.transform.position = new Vector3(gameObject.transform.position.x, below ? gameObject.transform.position.y - 1 : gameObject.transform.position.y + 1, gameObject.transform.position.z);


            gameObject.GetComponent<Combatable>().OnSelect_Attack(player);
        }
    }
}
