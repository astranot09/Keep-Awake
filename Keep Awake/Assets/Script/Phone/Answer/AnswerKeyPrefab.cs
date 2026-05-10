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

    [Header("Button Sprites")]
    [SerializeField] private Sprite playSprite;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite doneSprite;

    [Header("Progress")]
    [SerializeField] private float currTime;
    [SerializeField] private float maxTime;
    [SerializeField] private bool searching = false;
    [SerializeField] private bool done = false;

    private void Start()
    {
        keyAnswer.color = Color.black;

        UpdateButtonSprite();
    }

    private void Update()
    {
        if (!done && searching)
        {
            if (currTime < maxTime)
            {
                currTime += Time.deltaTime;
                ProgressTime();
            }
            else
            {
                done = true;
                searching = false;

                keyAnswer.color = Color.white;

                UpdateButtonSprite();
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

        ProgressTime();
        UpdateButtonSprite();
    }

    public void ButtonSearching()
    {
        if (!done)
        {
            searching = !searching;

            UpdateButtonSprite();
        }
    }

    private void ProgressTime()
    {
        progressBar.maxValue = maxTime;
        progressBar.value = currTime;
    }

    private void UpdateButtonSprite()
    {
        Image buttonImage = startButton.image;

        if (done)
        {
            buttonImage.sprite = doneSprite;
        }
        else if (searching)
        {
            buttonImage.sprite = pauseSprite;
        }
        else
        {
            buttonImage.sprite = playSprite;
        }
    }
}