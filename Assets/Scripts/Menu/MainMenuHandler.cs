using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuHandler : MonoBehaviour {
	//Creates a private variable that is a list containing the UI Canvases for the different main menu screens
	//The indecies should follow the following outline:
	//Index 0: The Main Menu
	//Index 1: Options Menu
	//Index 2: Credits Menu
	//SerializeField allows this private variable to be visible in the MenuHandler component in the Unity Editor
	[SerializeField] private List<GameObject> uiCanvasList;

	//Creates a private variable that is a list containing the "First Selection" buttons for each of the UI Canvases
	//The indecies are representative of the same menus as the uiCanvasList
	//SerializeField allows this private variable to be visible in the MenuHandler component in the Unity Editor
	[SerializeField] private List<GameObject> firstSelectionButtonList;

	//Start automatically runs when the scene loads
	public void Start() {
		//Ensure that credits and options are disabled and that the main menu is enabled
		//Just calls the OnClick_BackToBase function in order to reduce the amount of repeated code
		OnClick_BackToBase();
	}

	public void OnClick_Begin() {
		SceneManager.LoadScene(1);
	}

	public void OnClick_Options() {
		//ensures that there is a button selected so that users can navigate the menu
		firstSelectionButtonList[1].GetComponent<Button>().Select();
		//disables the main menu and enables the options menu so that we can swap between them
		uiCanvasList[0].SetActive(false);
		uiCanvasList[1].SetActive(true);
	}

	public void OnClick_Exit() {
		Application.Quit();
	}

	public void OnClick_Credits() {
		//ensures that there is a button selected so that users can navigate the menu
		firstSelectionButtonList[2].GetComponent<Button>().Select();
		//disables the main menu and enables the credits menu so that we can swap between them
		uiCanvasList[0].SetActive(false);
		uiCanvasList[2].SetActive(true);
	}

	public void OnClick_BackToBase() {
		//ensures that there is a button selected so that users can navigate the menu
		firstSelectionButtonList[0].GetComponent<Button>().Select();
		//Disables the credits and options menu while enabling the main menu
		//The reason for disabling two menus is so that this can be used for
		//return to the main menu from both the credits and options menu
		uiCanvasList[0].SetActive(true);
		uiCanvasList[1].SetActive(false);
		uiCanvasList[2].SetActive(false);
	}
}
