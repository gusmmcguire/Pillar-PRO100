using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveableCombat : MonoBehaviour
{
	private bool canMoveAgain = true;
	[SerializeField] private GameObject selectorObject;
	public Collider2D currentCollider;
	public Vector3 prevPosition;
	public Vector2 directionVector;

	private void FixedUpdate() {
		if(currentCollider){
			if (currentCollider.CompareTag("Enemy")) {
				//logic for where to move next to enemy
				bool below = directionVector.y < 0 ? true : false;
				bool left = directionVector.x < 0 ? true : false;
				gameObject.transform.position = new Vector3(left ? gameObject.transform.position.x - 1 : gameObject.transform.position.x + 1, below ? gameObject.transform.position.y- 1 : gameObject.transform.position.y + 1, gameObject.transform.position.z);
				gameObject.GetComponent<Combatable>().OnSelect_Attack(currentCollider.gameObject);
			}else{
				gameObject.transform.position = prevPosition;
			}
		}
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
		if(!selectorObject) gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y - 1, 0);
		else selectorObject.GetComponent<Transform>().position = new Vector3(selectorObject.GetComponent<Transform>().position.x, selectorObject.GetComponent<Transform>().position.y - 1, 0);
	}

	private void OnMove_Up() {
		if (!selectorObject) gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y + 1, 0);
		else selectorObject.GetComponent<Transform>().position = new Vector3(selectorObject.GetComponent<Transform>().position.x, selectorObject.GetComponent<Transform>().position.y + 1, 0);
	}

	private void OnMove_Left() {
		if (!selectorObject) gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x - 1, gameObject.GetComponent<Transform>().position.y, 0);
		else selectorObject.GetComponent<Transform>().position = new Vector3(selectorObject.GetComponent<Transform>().position.x - 1, selectorObject.GetComponent<Transform>().position.y, 0);
	}

	private void OnMove_Right() {
		if (!selectorObject) gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x + 1, gameObject.GetComponent<Transform>().position.y, 0);
		else selectorObject.GetComponent<Transform>().position = new Vector3(selectorObject.GetComponent<Transform>().position.x + 1, selectorObject.GetComponent<Transform>().position.y, 0);
	}
	IEnumerator WaitForMove() {
		yield return new WaitForSeconds(.1f);
		canMoveAgain = true;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("CameraBounding")) return;
		currentCollider = collision;
		
	}
	private void OnTriggerExit2D(Collider2D collision) {
		currentCollider = null;
	}
}
