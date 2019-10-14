using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Inspector Fields
    [Header("Game Manager Setting")]
    [SerializeField] private int coinsInLevel;
    
    // Private Variables
    private int coinsCollected;

    public void GotoNextLevel()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if(nextScene + 1 > sceneCount)
        {
            // TODO: Handle Game Over
            return;
        }

        SceneManager.LoadScene(nextScene);
    }

    public void RespawnPlayer()
    {
        int currentScene =  SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void AddCoin()
    {
        coinsCollected += 1;
    }
}
