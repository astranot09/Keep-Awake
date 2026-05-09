using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private Slider awakeBar;



    public void UpdateTimerUI(float currTime)
    {
        int minutes = Mathf.FloorToInt(currTime / 60);
        int seconds = Mathf.FloorToInt(currTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void UpdateAwakeBarUI(float currTime, float maxTime)
    {
        awakeBar.value = currTime;
        awakeBar.maxValue = maxTime;
    }
}
