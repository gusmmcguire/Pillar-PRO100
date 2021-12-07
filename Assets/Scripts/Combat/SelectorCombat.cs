using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectorCombat : MonoBehaviour {

	[SerializeField] private Camera worldCamera;
	[SerializeField] private GameObject associatiedCharacter;
	public bool mouseHasControl = false;
	private bool tileType = true; //true = MoveTile, false = AttackTile
	public bool TileType { get => tileType; }

	private void Update() {
		if (!associatiedCharacter) return;
		if (Mouse.current.delta.ReadUnprocessedValue().x != 0 || Mouse.current.delta.ReadUnprocessedValue().y != 0) {
			gameObject.GetComponent<Transform>().position = worldCamera.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadUnprocessedValue().x, Mouse.current.position.ReadUnprocessedValue().y, 0));
			mouseHasControl = true;
		}
		else if (mouseHasControl) {
			mouseHasControl = false;
		}
		
		if (!associatiedCharacter.GetComponent<RangeHighlight>().IsHighlighting)
        {
			int range = tileType ? associatiedCharacter.GetComponent<Statable>().GetCharaMoveRange() : associatiedCharacter.GetComponent<Statable>().GetCharaAttackRange();
			associatiedCharacter.GetComponent<RangeHighlight>().ShowHighlight(range, tileType);
        }
	}

	public void OnSubmit_Move(InputAction.CallbackContext context) {
		if (!context.performed) return;
		associatiedCharacter.GetComponent<RangeHighlight>().hideHighlight();

		MoveableCombat moveable = associatiedCharacter.GetComponent<MoveableCombat>();
		moveable.directionVector = associatiedCharacter.GetComponent<Combatable>().OnHover_CheckDistance(gameObject.transform);
		
		if (moveable.directionVector.magnitude <= associatiedCharacter.GetComponent<Statable>().GetCharaMoveRange()) {
			moveable.prevPosition = associatiedCharacter.transform.position;
			associatiedCharacter.transform.position = gameObject.transform.position;
			GameObject.Find("EventSystem").GetComponent<Turns>().ActionEconomy();
		}

	}

	public void ToggleTileType()
    {
		tileType = !tileType;
		associatiedCharacter.GetComponent<RangeHighlight>().hideHighlight();

    }

}
