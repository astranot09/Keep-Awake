using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("UI Inventory")]
    [SerializeField] private Transform content;
    [SerializeField] private GameObject itemPrefab;

    private void OnEnable()
    {
        GameManager.OnStart += RefreshUI;
    }
    private void OnDisable()
    {
        GameManager.OnStart -= RefreshUI;
    }
    

    public void RefreshUI()
    {
        // Hapus item lama
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        // Generate item baru
        foreach (ItemSO item in InventoryManager.instance.itemSOs)
        {
            GameObject obj = Instantiate(itemPrefab, content);

            ItemScript itemScript = obj.GetComponent<ItemScript>();

            itemScript.SetUp(item);
        }
    }
}
