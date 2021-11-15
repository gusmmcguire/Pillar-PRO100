using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceManager : MonoBehaviour {
	//lists that contains the references to the sprites of the different body parts for a character
	//the 0 index will be empty so that we can provide a blank model if necessary
	[SerializeField] private List<Sprite> hairSpriteList;
	[SerializeField] private List<Sprite> headSpriteList;
	[SerializeField] private List<Sprite> torsoSpriteList;
	[SerializeField] private List<Sprite> legsSpriteList;

	//these variables are references to the GameObjects that contain the SpriteRenderers for the various body parts
	//creates easy access to the necessary GameObjects for changing appearance
	[SerializeField] private GameObject hairObjectReference;
	[SerializeField] private GameObject headObjectReference;
	[SerializeField] private GameObject torsoObjectReference;
	[SerializeField] private GameObject legsObjectReference;

	[SerializeField] private int _hairIndex = 0;
	[SerializeField] private int _headIndex = 0;
	[SerializeField] private int _torsoIndex = 0;
	[SerializeField] private int _legsIndex = 0;

	public int HairIndex{
		get{ return _hairIndex; }
		set{
			if (value >= hairSpriteList.Count) _hairIndex = 0;
			else _hairIndex = value;
			OnChange_Hair();
		}
	}

	public int HeadIndex {
		get { return _headIndex; }
		set {
			if (value >= headSpriteList.Count) _headIndex = 0;
			else _headIndex = value;
			OnChange_Head();
		}
	}

	public int TorsoIndex {
		get { return _torsoIndex; }
		set {
			if (value >= torsoSpriteList.Count) _torsoIndex = 0;
			else _torsoIndex = value;
			OnChange_Torso();
		}
	}

	public int LegsIndex {
		get { return _legsIndex; }
		set {
			if (value >= legsSpriteList.Count) _legsIndex = 0;
			else _legsIndex = value;
			OnChange_Legs();
		}
	}

	private void Awake() {
		OnChange_Hair();
		OnChange_Head();
		OnChange_Torso();
		OnChange_Legs();
	}

	private void OnValidate() {
		HairIndex = _hairIndex;
		HeadIndex = _headIndex;
		TorsoIndex = _torsoIndex;
		LegsIndex = _legsIndex;
	}

	private void OnChange_Hair(){
		hairObjectReference.GetComponent<SpriteRenderer>().sprite = hairSpriteList[_hairIndex];
	}

	private void OnChange_Head() {
		headObjectReference.GetComponent<SpriteRenderer>().sprite = headSpriteList[_headIndex];
	}

	private void OnChange_Torso() {
		torsoObjectReference.GetComponent<SpriteRenderer>().sprite = torsoSpriteList[_torsoIndex];
	}
	private void OnChange_Legs() {
		legsObjectReference.GetComponent<SpriteRenderer>().sprite = legsSpriteList[_legsIndex];
	}
}
