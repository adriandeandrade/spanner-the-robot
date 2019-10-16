using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelOverScreen : MonoBehaviour
{
	// Inspector Fields
	[SerializeField] private TextMeshProUGUI coinsCollectedText;

	public void SetCoinsCollectedText()
	{
		int coinsCollected = Toolbox.instance.GetGameManager().GetCoinsCollected();
		int coinsInLevel = Toolbox.instance.GetGameManager().GetCoinsInLevel();

		coinsCollectedText.SetText("Coins Collected: " + coinsCollected + " / " + coinsInLevel);
	}

	public void NextLevel()
	{
		Toolbox.instance.GetGameManager().GotoNextLevel();
	}

	public void Exit()
	{
		// TODO: Go to main menu.
	}
}
