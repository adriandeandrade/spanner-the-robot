using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// Inspector Fields
	[Header("Game Manager Setting")]
	[SerializeField] private int coinsInLevel;
	[SerializeField] private GameObject levelOverPanel;
	[SerializeField] private GameObject pauseScreenPanel;

	// Private Variables
	private int coinsCollected;
	private bool paused;

	public void GotoNextLevel()
	{
		int sceneCount = SceneManager.sceneCountInBuildSettings;
		int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

		if (nextScene + 1 > sceneCount)
		{
			// TODO: Handle Game Over
			return;
		}

		SceneManager.LoadScene(nextScene);
        Time.timeScale = 1;
        levelOverPanel.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (paused)
			{
				paused = false;
				DisablePauseScreen();
			}
			else
			{
				paused = true;
                ShowPauseScreen();
			}
		}
	}

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

	public void RespawnPlayer()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene);
	}

	public void AddCoin()
	{
		coinsCollected += 1;
	}

	public void ShowPauseScreen()
	{
		pauseScreenPanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void DisablePauseScreen()
	{
		pauseScreenPanel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void LevelOver()
	{
        levelOverPanel.SetActive(true);
        levelOverPanel.GetComponent<LevelOverScreen>().SetCoinsCollectedText();
        Time.timeScale = 0f;
	}

    public int GetCoinsCollected()
    {
        return coinsCollected;
    }

    public int GetCoinsInLevel()
    {
        return coinsInLevel;
    }
}
