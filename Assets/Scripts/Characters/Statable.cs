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
    private int CharaHealth;
    //MP
    [SerializeField] private int CharaMaxMana;
    private int CharaMana;
    //AP
    [SerializeField] private int CharaMaxAP;
    private int CharaAP;
    //IsKilled;
    private bool isKilled = false;

    public void Awake()
    {
        CharaComposition = 10;
        CharaMuscle = 10;
        CharaFerocity = 10;
        CharaSanity = 3;
        CharaKnowledge = 10;
        CharaFrenzy = 10;
        CharaMoveRange = 5;
        CharaAttackRange = 2;
        CharaMaxHealth = 20;
        CharaHealth = 20;
        CharaMaxMana = 20;
        CharaMana = 20;
    }

    //SideCharacterStats to go Here-ish(Porbably use random to generate a concrete value)
    //Legendary Character stats to go below this ^ (Needs to be CONCRETE)

    //Getter and setter for Composition
    public int GetCharaComposition()
    {
        return CharaComposition;
    }
     public void SetCharaComposition(int Comp)
    {
        CharaComposition = Comp;
        CharaMaxHealth = 10 + CharaComposition;
    }
    //Getter and setter for Muscle
    public int GetCharaMuscle()
    {
        return CharaMuscle;
    }
    public void SetCharaMuscle(int Muscle)
    {
        CharaMuscle = Muscle;
    }

    //Getter and setter for Ferocity
    public int GetCharaFerocity()
    {
        return CharaFerocity;
    }
    public void SetCharaFerocity(int Fero)
    {
        //Does this work how I think it works?
        CharaFerocity = CharaMuscle + Fero;
    }

    //Getter and setter for Sanity
    public int GetCharaSanity()
    {
        return CharaSanity;
    }
    public void SetCharaSanity(int Sane)
    {
       CharaSanity = Sane;
    }

    //Getter and setter for Knowledge
    public int GetCharaKnowledge()
    {
        return CharaKnowledge;
    }
    public void SetCharaKnowledge(int Knowledge)
    {
        CharaKnowledge = Knowledge;
        CharaMaxMana = 10 + CharaKnowledge;
    }

    //Getter and Setter for Frenzy
    public int GetCharaFrenzy()
    {
        return CharaFrenzy;
    }
    public void SetCharaFrenzy(int Frenzy)
    {
        CharaFrenzy = Frenzy;
    }

    //Getter and setter for MoveRange
    public int GetCharaMoveRange()
    {
        return CharaMoveRange;
    }
    public void SetCharaMoveRange(int MoveRange)
    {
        //5 Appears, to me, as a reasonable average move speed
        CharaMoveRange = MoveRange;
    }

    //Getter and setter for AttackRange
    public int GetCharaAttackRange()
    {
        return CharaAttackRange;
    }
    public void SetCharaAttackRange(int SwingRange)
    {
        //Attack Range extends from tile movement and should vary depending on action taken
        CharaAttackRange = SwingRange;
    }

    //Getter and setter for MaxHealth
    public int GetCharaMaxHealth()
    {
        return CharaMaxHealth;
    }



    //Getter and setter for MaxMana
    public int GetCharaMaxMana()
    {
        return CharaMaxMana;
    }
    
    //Getter and setter for Health
    public int GetCharaHealth()
    {
        return CharaHealth;
    }
    public void SetCharaHealth(int health = 10)
    {
        CharaHealth = health;
        if (CharaHealth <= 0) isKilled = true;
        else if (isKilled) isKilled = false;
    }

    //Getter and setter for MaxMana
    public int GetCharaMana()
    {
        return CharaMana;
    }
    public void SetCharaMana(int mana = 10)
    {
        CharaMana = mana;
    }

    //Getter for isKilled
    public bool GetIsKilled()
    {
        return isKilled;
    }
}
