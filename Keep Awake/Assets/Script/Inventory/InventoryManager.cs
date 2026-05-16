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
        if (itemSOs.Count >= 4) return;
        itemSOs.Add(itemSO);
        InventoryUI.instance.RefreshUI();
    }

    public void RemoveItem(ItemSO itemSO)
    {
        itemSOs.Remove(itemSO);
    }
}