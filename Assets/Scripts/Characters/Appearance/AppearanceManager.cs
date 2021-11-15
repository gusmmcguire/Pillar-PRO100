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

	//contains the index values of each body part
	//these are serialized fields so that we can change them in the editor at runtime
	[SerializeField] private int _hairIndex = 0;
	[SerializeField] private int _headIndex = 0;
	[SerializeField] private int _torsoIndex = 0;
	[SerializeField] private int _legsIndex = 0;

	//these C# properties are used for setting the values of the respective body part index
	//when changing the values in code, these should be used
	//instead of _hairIndex = 2;
	//we do HairIndex = 2;
	//this is so that custom logic can be run when the value gets set and we can update the sprite renderer appropriately
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

	//this is called when the script component becomes active in the scene and ensures that the appearance is displayed correctly
	private void Awake() {
		OnChange_Hair();
		OnChange_Head();
		OnChange_Torso();
		OnChange_Legs();
	}

	//this will be called only in the unity editor whenever any variable in this script is updated
	//this will use the C# properties defined above to run the custom logic to set the body part indexes
	//PROCESS:
	//_hairIndex is changed to 0 in editor
	//_hairIndex is now 0
	//OnValidate() is run
	//HairIndex = _hairIndex
	//_hairIndex is checked to be in usable range
	//_hairIndex is reassigned if necessary
	//OnChange_Hair() is called
	//the appearance change is reflected in the game
	private void OnValidate() {
		HairIndex = _hairIndex;
		HeadIndex = _headIndex;
		TorsoIndex = _torsoIndex;
		LegsIndex = _legsIndex;
	}

	//sets the hair appearance to the appropriate sprite based on _hairIndex
	private void OnChange_Hair(){
		hairObjectReference.GetComponent<SpriteRenderer>().sprite = hairSpriteList[_hairIndex];
	}

	//sets the head appearance to the appropriate sprite based on _headIndex
	private void OnChange_Head() {
		headObjectReference.GetComponent<SpriteRenderer>().sprite = headSpriteList[_headIndex];
	}

	//sets the torso appearance to the appropriate sprite based on _torsoIndex
	private void OnChange_Torso() {
		torsoObjectReference.GetComponent<SpriteRenderer>().sprite = torsoSpriteList[_torsoIndex];
	}

	//sets the legs appearance to the appropriate sprite based on _legsIndex
	private void OnChange_Legs() {
		legsObjectReference.GetComponent<SpriteRenderer>().sprite = legsSpriteList[_legsIndex];
	}
}
