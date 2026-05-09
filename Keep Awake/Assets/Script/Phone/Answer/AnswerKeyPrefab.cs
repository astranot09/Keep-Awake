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
    [SerializeField] private bool done;

    private void Start()
    {
        keyAnswer.enabled = false;
    }
    private void Update()
    {
        if (!done)
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

    private void ProgressTime()
    {
        progressBar.maxValue = maxTime;
        progressBar.value = currTime;
    }
}
