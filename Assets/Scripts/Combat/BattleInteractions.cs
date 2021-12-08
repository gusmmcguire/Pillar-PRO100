using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleInteractions : MonoBehaviour
{
    static GameObject canvasGameOver;
    static GameObject canvasGameWin;
    static GameObject[] apUI = new GameObject[3];

    static Sprite unspentAP;
    static Sprite spentAP;

    private void Awake()
    {
        canvasGameOver = GameObject.Find("GameOver");
        canvasGameOver.SetActive(false);
        canvasGameWin = GameObject.Find("GameWin");
        canvasGameWin.SetActive(false);
        apUI[0] = GameObject.Find("imageAP1");
        apUI[1] = GameObject.Find("imageAP2");
        apUI[2] = GameObject.Find("imageAP3");
        unspentAP = Resources.Load<Sprite>("Art/APFull");
        spentAP = Resources.Load<Sprite>("Art/APUsed");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextMap()
    {

        int randInt = Random.Range(1, 6);
        SceneManager.LoadScene(1 + randInt);
    }

    public static IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        canvasGameOver.SetActive(true);
        GameObject.Find("Menu").GetComponent<Button>().Select();
    }

    public static IEnumerator GameWin()
    {
        yield return new WaitForSeconds(1.5f);
        canvasGameWin.SetActive(true);
        GameObject.Find("Menu").GetComponent<Button>().Select();
    }

    public static void DisableAPUI(int numAP)
    {
        apUI[numAP].GetComponent<Image>().sprite = spentAP;
    }
    
    public static void EnableAPUI(int numAP)
    {
        apUI[numAP].GetComponent<Image>().sprite = unspentAP;
    }

    public static void EnableAllAPUI()
    {
        EnableAPUI(0);
        EnableAPUI(1);
        EnableAPUI(2);
    }
}
