using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectorCombat : MonoBehaviour
{

	[SerializeField] private Camera worldCamera;
    [SerializeField] private GameObject associatiedCharacter;
	public bool mouseHasControl = false;

	private void Update() {
		if(Mouse.current.delta.ReadUnprocessedValue().x != 0 || Mouse.current.delta.ReadUnprocessedValue().y != 0) {
			gameObject.GetComponent<Transform>().position = worldCamera.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadUnprocessedValue().x, Mouse.current.position.ReadUnprocessedValue().y, 0));
			mouseHasControl = true;
		}else if(mouseHasControl){
			mouseHasControl = false;
		}
	}

	public void OnSubmit_Move(InputAction.CallbackContext context){
		//check ability to move here
		associatiedCharacter.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
	}	
}
