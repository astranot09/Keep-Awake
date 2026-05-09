using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AnswerKeyPrefab : MonoBehaviour
{
    [Header("Setup")]
    public TMP_Text index;
    public Slider progressBar;
    public Button startButton;

    public Image keyAnswer;

    public QuestionSO questionSO;

    [Header("Progress")]
    [SerializeField] private float currTime;
    [SerializeField] private float maxTime;
    [SerializeField] private bool searching = false;
    [SerializeField] private bool done = false;

    private void Start()
    {
        keyAnswer.enabled = false;
    }
    private void Update()
    {
        if (!done && searching)
        {
            if (currTime > 0)
            {
                currTime -= Time.deltaTime;
                ProgressTime();
            }
            else
            {
                done = true;
            }
        }
    }

    public void SetUpAnswerKeyPrefab(QuestionSO x, float max)
    {
        questionSO = x;

        maxTime = max;
        currTime = maxTime;

        index.text = questionSO.name;
        keyAnswer.sprite = questionSO.questionSprite;

        startButton.onClick.AddListener(ButtonSearching);
    }

    public void ButtonSearching()
    {
        if (!done)
        {
            if (!searching)
            {
                searching = true;
            }
            else
                searching = false;
        }
    }

    private void ProgressTime()
    {
        progressBar.maxValue = maxTime;
        progressBar.value = currTime;
    }
}
