using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Inventory inv;
    [SerializeField] private ItemData data;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inv.AddItemToInventory(data);
            Destroy(gameObject);
        }
    }
}
