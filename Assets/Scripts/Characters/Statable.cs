using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    //REMOVE SERIALIZEFIELD WHEN DONE
    [SerializeField] private int CharaHealth;
    //MP
    [SerializeField] private int CharaMaxMana;
    private int CharaMana;
    //AP
    [SerializeField] private int CharaMaxAP;
    private int CharaAP;
    //IsKilled;
    private bool isKilled = false;
    public bool IsKilled
    {
        get => isKilled;
    }

    public void Awake()
    {
        if(gameObject.GetComponent<AppearanceManager>()) gameObject.GetComponent<UtilFuncs>().Load();
        if(gameObject.CompareTag("Player"))
        {
            DisplayHealth();
        }
    }
    public void DisplayHealth()
    {
        GameObject.Find("textHP").GetComponent<TextMeshProUGUI>().text = $"{GetCharaHealth()} / {GetCharaMaxHealth()}";
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
        CharaMoveRange = Mathf.FloorToInt((CharaMuscle + CharaFrenzy) / 3.0f);
    }

    //Getter and setter for Ferocity
    public int GetCharaFerocity()
    {
        return CharaFerocity;
    }
    public void SetCharaFerocity(int Fero)
    {
        //Does this work how I think it works?
        CharaFerocity = Fero;
        CharaAttackRange = Mathf.FloorToInt(CharaFerocity / 2.0f);
        CharaAttackRange = (CharaAttackRange == 0) ? 1 : CharaAttackRange;
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
        CharaMoveRange = Mathf.FloorToInt((CharaMuscle + CharaFrenzy) / 3.0f);
    }

    //Getter and setter for MoveRange
    public int GetCharaMoveRange()
    {
        return CharaMoveRange;
    }

    //Getter and setter for AttackRange
    public int GetCharaAttackRange()
    {
        return CharaAttackRange;
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
        if (CharaHealth <= 0)
        {
            isKilled = true;
            gameObject.GetComponent<Combatable>().OnDeath_Destroy();
        }
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
}
