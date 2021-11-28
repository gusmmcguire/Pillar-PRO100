using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float timeToDelete = 0.2f;
	public bool shouldFloat = false;
	private bool coroutineRunning = false;

	private void Update() {
		if(shouldFloat){
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (float)(0.5 * Time.deltaTime), gameObject.transform.position.z);
			if(!coroutineRunning) StartCoroutine(OnEnd_InvisibleText());
		}
	}

	IEnumerator OnEnd_InvisibleText(){
		coroutineRunning = true;
        yield return new WaitForSeconds(timeToDelete);
		gameObject.GetComponent<TextMeshProUGUI>().text = "";
		shouldFloat = false;
		coroutineRunning = false;
	}
}
