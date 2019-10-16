using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	// Private Variables
	private GameManager gameManager;

	
	private void Start()
	{   
        gameManager = Toolbox.instance.GetGameManager();
	}

	public void Resume()
	{
        gameManager.DisablePauseScreen();
	}

	public void Options()
	{

	}

	public void Exit()
	{
        // TODO: Go to main menu here.
	}
}
