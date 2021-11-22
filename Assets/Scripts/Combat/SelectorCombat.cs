using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectorCombat : MonoBehaviour {

	[SerializeField] private Camera worldCamera;
	[SerializeField] private GameObject associatiedCharacter;
	private bool canMoveAgain = true;
	public bool mouseHasControl = false;

	private void Update() {
		if (Mouse.current.delta.ReadUnprocessedValue().x != 0 || Mouse.current.delta.ReadUnprocessedValue().y != 0) {
			gameObject.GetComponent<Transform>().position = worldCamera.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadUnprocessedValue().x, Mouse.current.position.ReadUnprocessedValue().y, 0));
			mouseHasControl = true;
		}
		else if (mouseHasControl) {
			mouseHasControl = false;
		}
	}

	public void OnSubmit_Move(InputAction.CallbackContext context) {
		if (canMoveAgain) {
			Statable stats = associatiedCharacter.GetComponent<Statable>();
			associatiedCharacter.GetComponent<MoveableCombat>().directionVector = associatiedCharacter.GetComponent<Combatable>().OnHover_CheckDistance(gameObject.transform);
			if (associatiedCharacter.GetComponent<MoveableCombat>().directionVector.magnitude <= stats.GetCharaMoveRange()) {
				associatiedCharacter.GetComponent<MoveableCombat>().prevPosition = associatiedCharacter.transform.position;
				associatiedCharacter.transform.position = gameObject.transform.position;
				canMoveAgain = false;
				StartCoroutine(WaitForMove());
			}
		}
	}

	IEnumerator WaitForMove() {
		yield return new WaitForSeconds(.5f);
		canMoveAgain = true;
	}
}
