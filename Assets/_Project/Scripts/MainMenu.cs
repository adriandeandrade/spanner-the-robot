using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Inspector Fields
    [SerializeField] private GameManager gameManager;

    public void Play()
    {
        gameManager.GotoNextLevel();
    }

    public void Options()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
