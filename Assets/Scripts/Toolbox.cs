using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
	#region Singleton
	public static Toolbox instance;

	private void InitSingleton()
	{
		if (instance == null)
		{
			instance = this;
		}

		DontDestroyOnLoad(gameObject);
	}
	#endregion

	private void Awake()
	{
		InitSingleton();

	}

}