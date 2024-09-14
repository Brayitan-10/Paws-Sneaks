using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void ChangeLevel1()
    {
        int actualLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualLevel + 1);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int actualLevel = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(actualLevel + 1);
        }
    }
}