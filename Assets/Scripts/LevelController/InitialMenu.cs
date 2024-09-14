using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        Debug.Log("Juego cerrado.");
        Application.Quit();
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}