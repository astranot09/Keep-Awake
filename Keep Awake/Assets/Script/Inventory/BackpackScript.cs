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
            SoundManager.instance.PlaySFX(SoundManager.instance.zipperOpen);
            //mainin suara buka
        }
        else
        {
            Debug.Log("Tutup tas");
            SoundManager.instance.PlaySFX(SoundManager.instance.zipperClose);
            //mainin suara tutup
        }
    }
}
