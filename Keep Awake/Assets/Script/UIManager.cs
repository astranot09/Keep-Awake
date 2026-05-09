using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    [SerializeField] private TMP_Text timerText;
    public void UpdateTimerUI(float currTime)
    {
        int minutes = Mathf.FloorToInt(currTime / 60);
        int seconds = Mathf.FloorToInt(currTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
