using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statable : MonoBehaviour
{
    //Hitpoint Increase/Decrease
    private int CharaComposition = 3;
    //Added Damage
    private int CharaMuscle = 2;
    //Average Damage
    private int CharaFerocity = 10;
    //Mental State
    private int CharaSanity = 15;
    //Magic/Power know-how
    private int CharaKnowledge = 2;
    //Character "Barbaric rage"?
    private int CharaFrenzy = 2;
    //Range of tiles
    private int CharaMoveRange = 5;
    //Attacks after tile movement
    private int CharaAttackRange = 2;
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
        CharaComposition = CharaComposition;
        CharaMaxHealth = 10 + CharaComposition
    }
    //Getter and setter for Muscle
    [SerializeField] public int GetCharaMuscle()
    {
        return CharaMuscle;
    }
    [SerializeField] public void SetCharaMuscle(int Muscle)
    {
        CharaMuscle = CharaMuscle;
    }

    //Getter and setter for Ferocity
    [SerializeField] public int GetCharaFerocity()
    {
        return CharaFerocity;
    }
    [SerializeField] public void SetCharaFerocity(int Fero)
    {
        //Does this work how I think it works?
        CharaFerocity = CharaMuscle + CharaFerocity;
    }

    //Getter and setter for Sanity
    [SerializeField] public int GetCharaSanity()
    {
        return CharaSanity;
    }
    [SerializeField] public void SetCharaSanity(int Sane)
    {
       CharaSanity = CharaSanity;
    }

    //Getter and setter for Knowledge
    [SerializeField] public int GetCharaKnowledge()
    {
        return CharaKnowledge;
    }
    [SerializeField] public void SetCharaKnowledge(int Knowledge)
    {
        CharaKnowledge = CharaKnowledge;
        CharaMaxMana = 10 + CharaKnowledge;
    }

    //Getter and Setter for Frenzy
    [SerializeField] public int GetCharaFrenzy()
    {
        return CharaFrenzy;
    }
    [SerializeField] public void SetCharaFrenzy(int Frenzy)
    {
        CharaFrenzy = CharaFrenzy;
    }

    //Getter and setter for MoveRange
    [SerializeField] public int GetCharaMoveRange()
    {
        return CharaMoveRange;
    }
    [SerializeField] public void SetCharaMoveRange(int MoveRange)
    {
        //5 Appears, to me, as a reasonable average move speed
        CharaMoveRange = CharaMoveRange;
    }

    //Getter and setter for AttackRange
    [SerializeField] public int GetCharaAttackRange()
    {
        return CharaAttackRange;
    }
    [SerializeField] public void SetCharaAttackRange(int SwingRange)
    {
        //Attack Range extends from tile movement and should vary depending on action taken
        CharaAttackRange = CharaAttackRange;
    }

    //Getter and setter for MaxHealth
    [SerializeField] public int GetCharaMaxHealth()
    {
        return CharaMaxHealth;
    }


    //Getter and setter for MaxMana
    [SerializeField] public int GetCharaMaxMana()
    {
        return CharaMaxMana;
    }

}
