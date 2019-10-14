using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Battery
}


[CreateAssetMenu(fileName = "New Item", menuName = "Items/ New Item")]
public class Item : ScriptableObject
{
	public string itemName;
	public ItemTypes itemType;
    public GameObject itemPrefab;
}
