using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject ressourceParent;
    [SerializeField] private GameObject equipmentParent;
    [SerializeField] private GameObject consumableParent;
    [SerializeField] private GameObject itemFrame;
    public List<GameObject> UIToDelete;
    private bool isInvOpen;
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Inventory>();
        CloseInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInvOpen = !isInvOpen;

            if(isInvOpen)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
    }

    private void CloseInventory()
    {
        inventoryPanel.SetActive(false);

        foreach(GameObject obj in UIToDelete)
        {
            Destroy(obj);
        }

        UIToDelete.Clear();
    }

    private void OpenInventory()
    {
        GameObject tmpItemFrame = null;

        inventoryPanel.SetActive(true);
        ShowRessources();

        foreach (ItemData item in inventory.itemsInInventory)
        {
            switch (item.itemType)
            {
                case ItemType.Ressource:
                    tmpItemFrame = Instantiate(itemFrame, ressourceParent.transform.position, ressourceParent.transform.rotation, ressourceParent.transform);
                    break;
                case ItemType.Equipment:
                    tmpItemFrame = Instantiate(itemFrame, equipmentParent.transform.position, equipmentParent.transform.rotation, equipmentParent.transform);
                    break;
                case ItemType.Consumable:
                    tmpItemFrame = Instantiate(itemFrame, consumableParent.transform.position, consumableParent.transform.rotation, consumableParent.transform);
                    break;
            }

            tmpItemFrame.GetComponent<RawImage>().texture = item.visual;
            tmpItemFrame.GetComponentInChildren<Text>().text = item.name;
            UIToDelete.Add(tmpItemFrame);
        }
    }

    public void ShowRessources()
    {
        ressourceParent.SetActive(true);
        equipmentParent.SetActive(false);
        consumableParent.SetActive(false);
    }

    public void ShowEquipments()
    {
        ressourceParent.SetActive(false);
        equipmentParent.SetActive(true);
        consumableParent.SetActive(false);
    }

    public void ShowConsumables()
    {
        ressourceParent.SetActive(false);
        equipmentParent.SetActive(false);
        consumableParent.SetActive(true);
    }
}
