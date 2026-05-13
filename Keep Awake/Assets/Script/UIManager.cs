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


    [Header("Submit")]
    public GameObject submitPanel;

    [Header("Finish")]
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalTimeText;


    [Header("MainMenu")]
    [SerializeField] private GameObject mainMenuPanel;


    public void CloseMainMenuPanel()
    {
        mainMenuPanel.SetActive(false);
        Player.instance.CloseUI();
    }

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


    public void OpenSubmitPanel()
    {
        if (!Player.instance.ReturnOpenUI())
        {
            submitPanel.SetActive(true);
            Player.instance.OpenUI();
        }
            
    }

    public void CloseSubmitPanel()
    {
        submitPanel.SetActive(false);
        Player.instance.CloseUI();
    }







    public void FinishSetUp(int score, float time)
    {
        finishPanel.SetActive(true);
        scoreText.text = $"SCORE : {score.ToString()}";
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        finalTimeText.text =
            $"REMAINING TIME : {minutes:00}:{seconds:00}";
    }

}
