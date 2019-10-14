using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteractable : InteractableItem
{
	public override void HandleItem()
	{
		Toolbox.instance.GetGameManager().AddCoin();
		base.HandleItem();
	}
}
