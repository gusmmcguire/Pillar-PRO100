using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectorCombat : MonoBehaviour
{

	[SerializeField] private Camera worldCamera;
    [SerializeField] private GameObject associatiedCharacter;
	private bool canMoveAgain = true;

	public bool mouseHasControl = false;

	private void Update() {
		if(Mouse.current.delta.ReadUnprocessedValue().x != 0 || Mouse.current.delta.ReadUnprocessedValue().y != 0) {
			gameObject.GetComponent<Transform>().position = worldCamera.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadUnprocessedValue().x, Mouse.current.position.ReadUnprocessedValue().y, 0));
			mouseHasControl = true;
		}else{
			mouseHasControl = false;
		}
	}

	public void OnSubmit_Move(InputAction.CallbackContext context){
		//check ability to move here
		associatiedCharacter.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
	}

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

	private void OnMove_Down() {
		gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y - 1, 0);
		Debug.Log("Moving!");
	}

	private void OnMove_Up() {
		gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y + 1, 0);
		Debug.Log("Moving!");
	}

	private void OnMove_Left() {
		gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x - 1, gameObject.GetComponent<Transform>().position.y, 0);
		Debug.Log("Moving!");
	}

	private void OnMove_Right() {
		gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x + 1, gameObject.GetComponent<Transform>().position.y, 0);
		Debug.Log("Moving!");
	}

	IEnumerator WaitForMove() {
		yield return new WaitForSeconds(.1f);
		canMoveAgain = true;
	}
}
