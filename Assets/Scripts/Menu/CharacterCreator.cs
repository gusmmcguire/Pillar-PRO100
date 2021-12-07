using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class CharacterCreator : MonoBehaviour {
	[SerializeField] private GameObject character;
	//  0   1     2     3       4        5        6       7       8       9      10
	//face-hair-torso-legs-composition-muscle-ferocity-sanity-knowledge-frenzy-points
	[SerializeField] private List<GameObject> textToUpdate;

	[SerializeField] private int pointsLeftToSpend = 21;

	private int CharaComposition = 1;
	private int CharaMuscle = 1;
	private int CharaFerocity = 1;
	private int CharaSanity = 1;
	private int CharaKnowledge = 1;
	private int CharaFrenzy = 1;
	
	public void Save() {
		string path = "Assets/SaveFiles/Characters/PlayerOne.txt";

		StreamWriter saveWriter = File.CreateText(path);

		saveWriter.WriteLine($"CharaComposition:{CharaComposition}");
		saveWriter.WriteLine($"CharaMuscle:{CharaMuscle}");
		saveWriter.WriteLine($"CharaFerocity:{CharaFerocity}");
		saveWriter.WriteLine($"CharaSanity:{CharaSanity}");
		saveWriter.WriteLine($"CharaKnowledge:{CharaKnowledge}");
		saveWriter.WriteLine($"CharaFrenzy:{CharaFrenzy}");

		saveWriter.WriteLine($"HeadIndex:{character.GetComponent<AppearanceManager>().HeadIndex}");
		saveWriter.WriteLine($"HairIndex:{character.GetComponent<AppearanceManager>().HairIndex}");
		saveWriter.WriteLine($"TorsoIndex:{character.GetComponent<AppearanceManager>().TorsoIndex}");
		saveWriter.WriteLine($"LegsIndex:{character.GetComponent<AppearanceManager>().LegsIndex}");

		saveWriter.Close();

		//Debug.Log(File.ReadAllText(path));
	}

	private void Awake() {
		UpdateText();
	}

	private void UpdateText() {
		textToUpdate[4].GetComponent<TextMeshProUGUI>().text = CharaComposition.ToString();
		textToUpdate[5].GetComponent<TextMeshProUGUI>().text = CharaMuscle.ToString();
		textToUpdate[6].GetComponent<TextMeshProUGUI>().text = CharaFerocity.ToString();
		textToUpdate[7].GetComponent<TextMeshProUGUI>().text = CharaSanity.ToString();
		textToUpdate[8].GetComponent<TextMeshProUGUI>().text = CharaKnowledge.ToString();
		textToUpdate[9].GetComponent<TextMeshProUGUI>().text = CharaFrenzy.ToString();
		textToUpdate[10].GetComponent<TextMeshProUGUI>().text = "Points To Spend: " + pointsLeftToSpend;
	}

	public void GoToMenu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
	public void GoToGame(){
		Save();
		UnityEngine.SceneManagement.SceneManager.LoadScene(2);
	}

	public void IncreaseFace() {
		character.GetComponent<AppearanceManager>().HeadIndex++;
		textToUpdate[0].GetComponent<TextMeshProUGUI>().text = character.GetComponent<AppearanceManager>().HeadIndex.ToString();
	}
	public void DecreaseFace() {
		character.GetComponent<AppearanceManager>().HeadIndex--;
		textToUpdate[0].GetComponent<TextMeshProUGUI>().text = character.GetComponent<AppearanceManager>().HeadIndex.ToString();
	}

	public void IncreaseHair() {
		character.GetComponent<AppearanceManager>().HairIndex++;
		textToUpdate[1].GetComponent<TextMeshProUGUI>().text = character.GetComponent<AppearanceManager>().HairIndex.ToString();
	}
	public void DecreaseHair() {
		character.GetComponent<AppearanceManager>().HairIndex--;
		textToUpdate[1].GetComponent<TextMeshProUGUI>().text = character.GetComponent<AppearanceManager>().HairIndex.ToString();
	}

	public void IncreaseTorso() {
		character.GetComponent<AppearanceManager>().TorsoIndex++;
		textToUpdate[2].GetComponent<TextMeshProUGUI>().text = character.GetComponent<AppearanceManager>().TorsoIndex.ToString();
	}
	public void DecreaseTorso() {
		character.GetComponent<AppearanceManager>().TorsoIndex--;
		textToUpdate[2].GetComponent<TextMeshProUGUI>().text = character.GetComponent<AppearanceManager>().TorsoIndex.ToString();
	}

	public void IncreaseLegs() {
		character.GetComponent<AppearanceManager>().LegsIndex++;
		textToUpdate[3].GetComponent<TextMeshProUGUI>().text = character.GetComponent<AppearanceManager>().LegsIndex.ToString();
	}
	public void DecreaseLegs() {
		character.GetComponent<AppearanceManager>().LegsIndex--;
		textToUpdate[3].GetComponent<TextMeshProUGUI>().text = character.GetComponent<AppearanceManager>().LegsIndex.ToString();
	}

	public void IncreaseComp() {
		if (pointsLeftToSpend > 0 && CharaComposition != 10) {
			CharaComposition++;
			pointsLeftToSpend--;
			UpdateText();
		}
	}
	public void DecreaseComp() {
		if (CharaComposition == 1) return;
		pointsLeftToSpend++;
		CharaComposition--;
		UpdateText();
	}
	
	public void IncreaseMuscle() {
		if (pointsLeftToSpend > 0 && CharaMuscle != 10) {
			CharaMuscle++;
			pointsLeftToSpend--;
			UpdateText();
		}
	}
	public void DecreaseMuscle() {
		if (CharaMuscle == 1) return;
		pointsLeftToSpend++;
		CharaMuscle--;
		UpdateText();
	}
	
	public void IncreaseFerocity() {
		if (pointsLeftToSpend > 0 && CharaFerocity != 10) {
			CharaFerocity++;
			pointsLeftToSpend--;
			UpdateText();
		}
	}
	public void DecreaseFerocity() {
		if (CharaFerocity == 1) return;
		pointsLeftToSpend++;
		CharaFerocity--;
		UpdateText();
	}
	
	public void IncreaseSanity() {
		if (pointsLeftToSpend > 0 && CharaSanity != 10) {
			CharaSanity++;
			pointsLeftToSpend--;
			UpdateText();
		}
	}
	public void DecreaseSanity() {
		if (CharaSanity == 1) return;
		pointsLeftToSpend++;
		CharaSanity--;
		UpdateText();
	}
	
	public void IncreaseKnowledge() {
		if (pointsLeftToSpend > 0 && CharaKnowledge != 10) {
			CharaKnowledge++;
			pointsLeftToSpend--;
			UpdateText();
		}
	}
	public void DecreaseKnowledge() {
		if (CharaKnowledge == 1) return;
		pointsLeftToSpend++;
		CharaKnowledge--;
		UpdateText();
	}
	
	public void IncreaseFrenzy() {
		if (pointsLeftToSpend > 0 && CharaFrenzy != 10) {
			CharaFrenzy++;
			pointsLeftToSpend--;
			UpdateText();
		}
	}
	public void DecreaseFrenzy() {
		if (CharaFrenzy == 1) return;
		pointsLeftToSpend++;
		CharaFrenzy--;
		UpdateText();
	}
}