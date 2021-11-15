using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovableOverworld : MonoBehaviour {

	private bool canMoveAgain = true;

	public void OnMove_CalcDir(InputAction.CallbackContext context) {
		if (canMoveAgain) {

			Vector2 movementVector = context.ReadValue<Vector2>();
			if (movementVector.x > 0) OnMove_Right();
			else if (movementVector.x != 0) OnMove_Left();

			if (movementVector.y > 0) OnMove_Up();
			else if (movementVector.y != 0) OnMove_Down();

			canMoveAgain = false;
			StartCoroutine(WaitForMove());
		}
	}

	public void OnMove_Down() {
		gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y - 1, gameObject.GetComponent<Transform>().position.z);
		Debug.Log("Moving!");
	}

	public void OnMove_Up() {
		gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y + 1, gameObject.GetComponent<Transform>().position.z);
		Debug.Log("Moving!");
	}

	public void OnMove_Left() {
		gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x - 1, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
		Debug.Log("Moving!");
	}

	public void OnMove_Right() {
		gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x + 1, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
		Debug.Log("Moving!");
	}

	IEnumerator WaitForMove(){
		yield return new WaitForSeconds(.2f);
		canMoveAgain = true;
	}
}
