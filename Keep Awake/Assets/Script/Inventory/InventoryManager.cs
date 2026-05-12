using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public List<ItemSO> itemSOs = new List<ItemSO>();

    public void AddItem(ItemSO itemSO)
    {
        itemSOs.Add(itemSO);
    }

    public void RemoveItem(ItemSO itemSO)
    {
        itemSOs.Remove(itemSO);
    }
}