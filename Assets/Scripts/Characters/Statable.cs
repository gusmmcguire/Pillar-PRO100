using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statable : MonoBehaviour
{
    //Hitpoint Increase/Decrease
    [SerializeField] private int CharaComposition;
    //Added Damage
    [SerializeField] private int CharaMuscle;
    //Average Damage
    [SerializeField] private int CharaFerocity;
    //Mental State
    [SerializeField] private int CharaSanity;
    //Magic/Power know-how
    [SerializeField] private int CharaKnowledge;
    //Character "Barbaric rage"?
    [SerializeField] private int CharaFrenzy;
    //Range of tiles
    [SerializeField] private int CharaMoveRange;
    //Attacks after tile movement
    [SerializeField] private int CharaAttackRange;
    //HP
    [SerializeField] private int CharaMaxHealth;
    //MP
    [SerializeField] private int CharaMaxMana;

    //SideCharacterStats to go Here-ish(Porbably use random to generate a concrete value)
    //Legendary Character stats to go below this ^ (Needs to be CONCRETE)


    //Getter and setter for Composition
    public int GetCharaComposition()
    {
        return CharaComposition;
    }
    [SerializeField] public void SetCharaComposition(int Comp)
    {
        CharaComposition = 3;
    }
    //Getter and setter for Muscle
    public int GetCharaMuscle()
    {
        return CharaMuscle;
    }
    public void SetCharaMuscle(int Muscle)
    {
        CharaMuscle = 2;
    }

    //Getter and setter for Ferocity
    public int GetCharaFerocity()
    {
        return CharaFerocity;
    }
    public void SetCharaFerocity(int Fero)
    {
        //Does this work how I think it works?
        CharaFerocity = CharaMuscle + 10;
    }

    //Getter and setter for Sanity
    public int GetCharaSanity()
    {
        return CharaSanity;
    }
    public void SetCharaSanity(int Sane)
    {
       CharaSanity = 15;
    }

    //Getter and setter for Knowledge
    public int GetCharaKnowledge()
    {
        return CharaKnowledge;
    }
    public void SetCharaKnowledge(int Knowledge)
    {
        CharaKnowledge = 2;
    }

    //Getter and Setter for Frenzy
    public int GetCharaFrenzy()
    {
        return CharaFrenzy;
    }
    public void SetCharaFrenzy(int Frenzy)
    {
        CharaFrenzy = 2;
    }

    //Getter and setter for MoveRange
    public int GetCharaMoveRange()
    {
        return CharaMoveRange;
    }
    public void SetCharaMoveRange(int MoveRange)
    {
        //5 Appears, to me, as a reasonable average move speed
        CharaMoveRange = 5;
    }

    //Getter and setter for AttackRange
    public int GetCharaAttackRange()
    {
        return CharaAttackRange;
    }
    public void SetCharaAttackRange(int SwingRange)
    {
        //Attack Range extends from tile movement and should vary depending on action taken
        CharaAttackRange = 2;
    }

    //Getter and setter for MaxHealth
    public int GetCharaMaxHealth()
    {
        return CharaMaxHealth;
    }
    public void SetCharaMaxHealth(int Health)
    {
        CharaMaxHealth = 10 + CharaComposition;
    }

    //Getter and setter for MaxMana
    public int GetCharaMaxMana()
    {
        return CharaMaxMana;
    }
    public void SetCharaMana(int Mana)
    {
        CharaMaxMana = 10 + CharaKnowledge;
    }
}
