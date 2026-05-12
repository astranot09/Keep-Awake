using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private Image itemImage;

    public void SetUp(ItemSO x)
    {
        itemSO = x;
        itemImage.sprite = itemSO.itemSprite;
    }

    public void OnClick()
    {
        // Pakai item
        AwakeBar.instance.AddAwakeInstan(itemSO.addAwake);

        // Hapus dari inventory
        InventoryManager.instance.RemoveItem(itemSO);

        // Hapus UI item
        Destroy(gameObject);
    }
}