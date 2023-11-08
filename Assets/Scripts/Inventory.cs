using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> itemsInInventory;

    public void AddItemToInventory(ItemData itemToAdd)
    {
        itemsInInventory.Add(itemToAdd);
    }

    public void RemoveItemFromInventory(ItemData itemToRemove)
    {
        itemsInInventory.Remove(itemToRemove);
    }
}
