using UnityEngine;

public class BackpackScript : MonoBehaviour
{
    public GameObject inventoryPanel;

    public void OnMouseDown()
    {
        if (Player.instance.ReturnOpenUI() && !inventoryPanel.activeSelf) return;

        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if (inventoryPanel.activeSelf)
        {
            Debug.Log("Buka tas");
            SoundManager.instance.PlaySFX(SoundManager.instance.zipperOpen);
            Player.instance.OpenUI();
            Player.instance.NotConcetrate();
        }
        else
        {
            Debug.Log("Tutup tas");
            SoundManager.instance.PlaySFX(SoundManager.instance.zipperClose);
            Player.instance.CloseUI();
            Player.instance.OnConcetrate();
        }
    }
}
