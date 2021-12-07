using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Combatable : MonoBehaviour {

	/// <summary>
	/// Checks the distance between currently active object and targeted object
	/// </summary>
	/// <param name="objectTransform">The object that the user is targeting</param>
	/// <returns>The distance between objects as an int</returns>
	public Vector2 OnHover_CheckDistance(Transform objectTransform) {
		return gameObject.GetComponent<UtilFuncs>().CheckDistance(objectTransform);
	}

	/// <summary>
	/// Calculates the chance to hit targeted object
	/// </summary>
	/// <remarks> The chance is based on Muscle + Ferocity - frenzy
	/// normalized against 15, penalized by low sanity and distance</remarks>
	/// <param name="objectTrasform">The object that the user is targeting</param>
	/// <returns>The chance to land an attack as a float</returns>
	public float OnHover_CalcHitChance(Transform objectTransform) {
		int muscle = gameObject.GetComponent<Statable>().GetCharaMuscle();
		int ferocity = gameObject.GetComponent<Statable>().GetCharaFerocity();
		int frenzy = gameObject.GetComponent<Statable>().GetCharaFrenzy();

		int sum = muscle + ferocity - (frenzy / 2);
		float hitChance = sum / 15.0f;

		int distance = (int)Mathf.Round(OnHover_CheckDistance(objectTransform).magnitude);
		if (distance > 3) {
			distance -= 3;
			float penalty = distance / 10.0f;
			hitChance -= penalty;
		}

		// Gets sanity and normalizes it against 7 to calculate the penalty for having low sanity
		int sanity = GetComponent<Statable>().GetCharaSanity();
		if (sanity < 7) {
			float normalizedSanity = sanity / 7.0f;
			hitChance *= normalizedSanity;
		}

		return (hitChance < 0) ? 0 : hitChance;
	}

	/// <summary>
	/// Initiates an attack between the active object and the targeted object
	/// </summary>
	/// <remarks>Damage is calculated by averaging Muscle and Ferocity</remarks>
	/// <param name="otherObject">The object that the user is targeting</param>
	public void OnSelect_Attack(GameObject otherObject) {
		int damage = (GetComponent<Statable>().GetCharaMuscle() + GetComponent<Statable>().GetCharaFerocity()) / 2;

		Combatable combatComponent = otherObject.GetComponent<Combatable>();

		if (combatComponent) {
			float hitChance = OnHover_CalcHitChance(gameObject.transform);
			float rndHit = UnityEngine.Random.Range(0.0f, 1.0f);
			//rndHit = rndHit > 1 ? 1 : rndHit;
			if (hitChance >= rndHit) {
				combatComponent.OnDamaged_LowerHealth(damage);
			}
			else {
				combatComponent.OnDamaged_DisplayDamage(0);
			}
		}
	}

	/// <summary>
	/// Lowers health based off of damage
	/// </summary>
	/// <param name="damage">Damage recieved</param>
	public void OnDamaged_LowerHealth(int damage) {
		int currentHealth = GetComponent<Statable>().GetCharaHealth();
		currentHealth -= damage;
		GetComponent<Statable>().SetCharaHealth(currentHealth);

		OnDamaged_DisplayDamage(damage);
	}

	/// <summary>
	/// Outputs the damage recieved next to the object
	/// </summary>
	/// <param name="damage">The amount of damage recieved</param>
	private void OnDamaged_DisplayDamage(int damage) {
		GameObject textObject = GameObject.Find("DamageText");
		string textToDisplay = (damage == 0) ? $"Miss" : $"{damage} damage";
		textObject.GetComponent<TextMeshProUGUI>().text = textToDisplay;

		float x = gameObject.transform.position.x + 0.45f;
		float y = gameObject.transform.position.y + 0.05f;
		float z = gameObject.transform.position.z - 1;
		
		textObject.transform.SetPositionAndRotation(new Vector3(x, y, z), new Quaternion());
		textObject.GetComponent<DamageText>().shouldFloat = true;
	}

	public void OnDeath_Destroy()
	{
		if (gameObject.GetComponent<Statable>().IsKilled == true)
		{
			GameObject eventSystem = GameObject.Find("EventSystem");
			if (gameObject.name == "Player")
            {
				eventSystem.GetComponent<Turns>().shouldGameEnd = true;
				eventSystem.GetComponent<Turns>().winLose = false;
            }else {
				GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
				if(gameObjects.Length <= 1)
                {
					eventSystem.GetComponent<Turns>().shouldGameEnd = true;
					eventSystem.GetComponent<Turns>().winLose = true;
				}
            }
			Destroy(gameObject);
			
		}
	}
}
