using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject menu, credit;
    public void Retry()
    {
        SceneManager.LoadScene("Ana Sahne");
    }

    public void Begin()
    {
        SceneManager.LoadScene("Ana Sahne");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    } 

    public void Back()
    {
        menu.SetActive(true);
        credit.SetActive(false);
    }

    public void Credit()
    {
        credit.SetActive(true);
        menu.SetActive(false);
    }
}
