using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float timeToDelete = 0.5f;
	public bool shouldFloat = false;

	private void Update() {
		if(shouldFloat){
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (float)(0.5 * Time.deltaTime), gameObject.transform.position.z);
			StartCoroutine(OnEnd_InvisibleText());
		}
	}

	IEnumerator OnEnd_InvisibleText(){
        yield return new WaitForSeconds(timeToDelete);
		gameObject.GetComponent<TextMeshProUGUI>().text = "";
		shouldFloat = false;
	}
}
