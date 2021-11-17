using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statable : MonoBehaviour
{
    //Hitpoint Increase/Decrease
    private int CharaComposition;
    //Added Damage
    private int CharaMuscle;
    //Average Damage
    private int CharaFerocity;
    //Mental State
    private int CharaSanity;
    //Magic/Power know-how
    private int CharaKnowledge;
    //Character "Barbaric rage"?
    private int CharaFrenzy;
    //Range of tiles
    private int CharaMoveRange;
    //Attacks after tile movement
    private int CharaAttackRange;
    //HP
    private int CharaMaxHealth;
    //MP
    private int CharaMaxMana;

    //SideCharacterStats to go Here-ish(Porbably use random to generate a concrete value)
    //Legendary Character stats to go below this ^ (Needs to be CONCRETE)


    //Getter and setter for Composition
    [SerializeField] public int GetCharaComposition()
    {
        return CharaComposition;
    }
    [SerializeField] public void SetCharaComposition(int Comp)
    {
        CharaComposition = 3;
    }
    //Getter and setter for Muscle
    [SerializeField] public int GetCharaMuscle()
    {
        return CharaMuscle;
    }
    [SerializeField] public void SetCharaMuscle(int Muscle)
    {
        CharaMuscle = 2;
    }

    //Getter and setter for Ferocity
    [SerializeField] public int GetCharaFerocity()
    {
        return CharaFerocity;
    }
    [SerializeField] public void SetCharaFerocity(int Fero)
    {
        //Does this work how I think it works?
        CharaFerocity = CharaMuscle + 10;
    }

    //Getter and setter for Sanity
    [SerializeField] public int GetCharaSanity()
    {
        return CharaSanity;
    }
    [SerializeField] public void SetCharaSanity(int Sane)
    {
       CharaSanity = 15;
    }

    //Getter and setter for Knowledge
    [SerializeField] public int GetCharaKnowledge()
    {
        return CharaKnowledge;
    }
    [SerializeField] public void SetCharaKnowledge(int Knowledge)
    {
        CharaKnowledge = 2;
    }

    //Getter and Setter for Frenzy
    [SerializeField] public int GetCharaFrenzy()
    {
        return CharaFrenzy;
    }
    [SerializeField] public void SetCharaFrenzy(int Frenzy)
    {
        CharaFrenzy = 2;
    }

    //Getter and setter for MoveRange
    [SerializeField] public int GetCharaMoveRange()
    {
        return CharaMoveRange;
    }
    [SerializeField] public void SetCharaMoveRange(int MoveRange)
    {
        //5 Appears, to me, as a reasonable average move speed
        CharaMoveRange = 5;
    }

    //Getter and setter for AttackRange
    [SerializeField] public int GetCharaAttackRange()
    {
        return CharaAttackRange;
    }
    [SerializeField] public void SetCharaAttackRange(int SwingRange)
    {
        //Attack Range extends from tile movement and should vary depending on action taken
        CharaAttackRange = 2;
    }

    //Getter and setter for MaxHealth
    [SerializeField] public int GetCharaMaxHealth()
    {
        return CharaMaxHealth;
    }
    [SerializeField] public void SetCharaMaxHealth(int Health)
    {
        CharaMaxHealth = 10 + CharaComposition;
    }

    //Getter and setter for MaxMana
    [SerializeField] public int GetCharaMaxMana()
    {
        return CharaMaxMana;
    }
    [SerializeField] public void SetCharaMana(int Mana)
    {
        CharaMaxMana = 10 + CharaKnowledge;
    }
}
