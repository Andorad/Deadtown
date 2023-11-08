using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "NewItem")]
public class ItemData : ScriptableObject
{
    public Texture visual;
    public string name;
    public GameObject prefab;
    public ItemType itemType;
}

public enum ItemType
{
    Ressource,
    Equipment,
    Consumable
}
