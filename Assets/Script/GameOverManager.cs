using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
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
}
