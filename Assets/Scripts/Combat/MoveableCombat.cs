using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveableCombat : MonoBehaviour
{
	[SerializeField] private GameObject selectorObject;
	public Collider2D currentCollider;
	public Vector3 prevPosition;
	public Vector2 directionVector;

	private void FixedUpdate() {
		if(currentCollider){
			if (currentCollider.CompareTag("Enemy")) {
				//logic for where to move next to enemy
				bool shouldBeHorizontal = Mathf.Abs(gameObject.transform.position.x - prevPosition.x) > Mathf.Abs(gameObject.transform.position.y - prevPosition.y);
				bool below = gameObject.transform.position.y - prevPosition.y > 0;
				bool left = gameObject.transform.position.x - prevPosition.x > 0;

				if(shouldBeHorizontal) gameObject.transform.position = new Vector3(left ? gameObject.transform.position.x - 1 : gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
				else gameObject.transform.position = new Vector3(gameObject.transform.position.x, below ? gameObject.transform.position.y- 1 : gameObject.transform.position.y + 1, gameObject.transform.position.z);
				
				
				gameObject.GetComponent<Combatable>().OnSelect_Attack(currentCollider.gameObject);

				gameObject.GetComponent<RangeHighlight>().hideHighlight();

				bool tileType = GameObject.Find("Selector").GetComponent<SelectorCombat>().TileType;

				int range = tileType ? gameObject.GetComponent<Statable>().GetCharaMoveRange() : gameObject.GetComponent<Statable>().GetCharaAttackRange();
				gameObject.GetComponent<RangeHighlight>().ShowHighlight(range, tileType);
				
			}
			else{
				gameObject.transform.position = prevPosition;
			}
		}
	}

	public void OnMove_CalcDir(InputAction.CallbackContext context) {
		if (!context.performed) return;
			Vector2 movementVector = context.ReadValue<Vector2>();
			if (movementVector.x > 0) OnMove_Right();
			else if (movementVector.x != 0) OnMove_Left();

			if (movementVector.y > 0) OnMove_Up();
			else if (movementVector.y != 0) OnMove_Down();
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

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("CameraBounding")) return;
		currentCollider = collision;
		
	}
	private void OnTriggerExit2D(Collider2D collision) {
		currentCollider = null;
	}
}
