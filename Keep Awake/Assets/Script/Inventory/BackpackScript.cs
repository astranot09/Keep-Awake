using UnityEngine;

public class BackpackScript : MonoBehaviour
{
    public GameObject inventoryPanel;

    public void BackpackInteract()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if (inventoryPanel.activeSelf)
        {
            Debug.Log("Buka tas");
            //mainin suara buka
        }
        else
        {
            Debug.Log("Tutup tas");
            //mainin suara tutup
        }
    }
}
