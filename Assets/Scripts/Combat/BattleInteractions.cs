using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleInteractions : MonoBehaviour
{
    static GameObject canvasGameOver;
    static GameObject canvasGameWin;

    private void Awake()
    {
        canvasGameOver = GameObject.Find("GameOver");
        canvasGameOver.SetActive(false);
        canvasGameWin = GameObject.Find("GameWin");
        canvasGameWin.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
}
