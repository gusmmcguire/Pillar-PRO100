using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilFuncs : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 CheckDistance(Transform objectTransform)
    {
        float x = Math.Abs(objectTransform.position.x - gameObject.transform.position.x);
        float y = Math.Abs(objectTransform.position.y - gameObject.transform.position.y);
        return new Vector2(x, y);
    }

    public bool Load()
    {
        Statable statable = gameObject.GetComponent<Statable>();
        AppearanceManager appManager = gameObject.GetComponent<AppearanceManager>();
        string path = "Assets/SaveFiles/Characters/PlayerOne.txt";

        if (!File.Exists(path)) return false;

        StreamReader loadReader = File.OpenText(path);
        string line = loadReader.ReadLine();
        statable.SetCharaComposition(int.Parse(line.Substring(line.IndexOf(':') + 1)));
        statable.SetCharaHealth(statable.GetCharaMaxHealth());
        
        line = loadReader.ReadLine();
        statable.SetCharaMuscle(int.Parse(line.Substring(line.IndexOf(':') + 1)));
        
        line = loadReader.ReadLine();
        statable.SetCharaFerocity(int.Parse(line.Substring(line.IndexOf(':') + 1)));

        line = loadReader.ReadLine();
        statable.SetCharaSanity(int.Parse(line.Substring(line.IndexOf(':') + 1)));

        line = loadReader.ReadLine();
        statable.SetCharaKnowledge(int.Parse(line.Substring(line.IndexOf(':') + 1)));

        line = loadReader.ReadLine();
        statable.SetCharaFrenzy(int.Parse(line.Substring(line.IndexOf(':') + 1)));
        
        line = loadReader.ReadLine();
        appManager.HeadIndex = int.Parse(line.Substring(line.IndexOf(':') + 1));
        
        line = loadReader.ReadLine();
        appManager.HairIndex = int.Parse(line.Substring(line.IndexOf(':') + 1));

        line = loadReader.ReadLine();
        appManager.TorsoIndex = int.Parse(line.Substring(line.IndexOf(':') + 1));
        
        line = loadReader.ReadLine();
        appManager.LegsIndex = int.Parse(line.Substring(line.IndexOf(':') + 1));

        Debug.Log(statable.ToString());

        return true;
    }
}
