using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatable : MonoBehaviour
{

    /// <summary>
    /// Checks the distance between currently active object and targeted object
    /// </summary>
    /// <param name="objectTransform">The object that the user is targeting</param>
    /// <returns>The distance between objects as an int</returns>
    public Vector2 OnHover_CheckDistance(Transform objectTransform)
    {
        return new Vector2(objectTransform.position.x, objectTransform.position.y);
    }

    /// <summary>
    /// Calculates the chance to hit targeted object
    /// </summary>
    /// <remarks> The chance is based on Muscle + Ferocity - frenzy
    /// normalized against 15, penalized by low sanity and distance</remarks>
    /// <param name="objectTrasform">The object that the user is targeting</param>
    /// <returns>The chance to land an attack as a float</returns>
    public float OnHover_CalcHitChance(Transform objectTrasform)
    {
        int sum = gameObject.GetComponent<Statable>().GetCharaMuscle() + GetComponent<Statable>().GetCharaFerocity() - (GetComponent<Statable>().GetCharaFrenzy() / 2);
        float hitChance = sum / 15.0f;

        // Gets sanity and normalizes it against 7 to calculate the penalty for having low sanity
        int sanity = GetComponent<Statable>().GetCharaSanity();
        if (sanity < 7 )
        {
            float normalizedSanity = sanity / 7;
            hitChance *= normalizedSanity;
        }
        
        int distance = (int)Mathf.Round(OnHover_CheckDistance(transform).magnitude);
        if (distance > 3)
        {
            distance -= 3;
            hitChance -= distance / 10.0f ;
        }

        return (hitChance < 0) ? 0 : hitChance;
    }

    /// <summary>
    /// Initiates an attack between the active object and the targeted object
    /// </summary>
    /// <remarks>Damage is calculated by averaging Muscle and Ferocity</remarks>
    /// <param name="otherObject">The object that the user is targeting</param>
    public void OnSelect_Attack(GameObject otherObject)
    {
        int damage = (GetComponent<Statable>().GetCharaMuscle() + GetComponent<Statable>().GetCharaFerocity()) / 2;

        Combatable combatComponent = otherObject.GetComponent<Combatable>();

        if(combatComponent)
        {
            combatComponent.OnDamaged_LowerHealth(damage);
        }
    }

    /// <summary>
    /// Lowers health based off of damage
    /// </summary>
    /// <param name="damage">Damage recieved</param>
    public void OnDamaged_LowerHealth(int damage)
    {
        int currentHealth = GetComponent<Statable>().GetCharaHealth();

        currentHealth -= damage;
        GetComponent<Statable>().SetCharaHealth(currentHealth);

        OnDamaged_DisplayDamage(damage);
    }

    /// <summary>
    /// Outputs the damage recieved next to the object
    /// </summary>
    /// <param name="damage">The amount of damage recieved</param>
    public void OnDamaged_DisplayDamage(int damage)
    {
        GameObject textObject = GameObject.Find("Damage Text");
        textObject.GetComponent<TextMesh>().text = $"{damage} damage";
        textObject.transform.position.Set(gameObject.transform.position.x + 0.5f, gameObject.transform.position.x + 0.5f, gameObject.transform.position.z + 1);
    }
}
