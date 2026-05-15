using UnityEngine;

public class BackpackScript : MonoBehaviour
{

    private void OnEnable()
    {
        LecturerScript.LectureAngry += CloseBackpack;
    }

    private void OnDisable()
    {
        LecturerScript.LectureAngry -= CloseBackpack;
    }

    public GameObject inventoryPanel;

    public void OnMouseDown()
    {
        if (Player.instance.ReturnOpenUI() && !inventoryPanel.activeSelf) return;

        if (!inventoryPanel.activeSelf)
        {
            OpenBackpack();
        }
        else
        {
            CloseBackpack();
        }
    }


    public void OpenBackpack()
    {
        inventoryPanel.SetActive(true);
        Debug.Log("Buka tas");
        SoundManager.instance.PlaySFX(SoundManager.instance.zipperOpen);
        Player.instance.OpenUI();
        Player.instance.NotConcetrate();
    }

    public void CloseBackpack()
    {
        inventoryPanel.SetActive(false);
        Debug.Log("Tutup tas");
        SoundManager.instance.PlaySFX(SoundManager.instance.zipperClose);
        Player.instance.CloseUI();
        Player.instance.OnConcetrate();
    }
}
