
using System.Collections.Generic;
using UnityEngine;

public class AnswerKeyManager : MonoBehaviour
{
    public static AnswerKeyManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Data")]
    [SerializeField] private List<QuestionSO> questionData;
    bool alreadySetUp;

    [Header("Spawning")]
    [SerializeField] private GameObject answerKeyPrefab;
    [SerializeField] private Transform answerKeyTransform;

    [Header("Searching")]
    [SerializeField] private bool onSearching;
    [SerializeField] private float maxTime;


    private void OnEnable()
    {
        GameManager.OnStart += SetUp;
    }
    private void OnDisable()
    {
        GameManager.OnStart -= SetUp;
    }

    public void SetUp()
    {
        if(alreadySetUp) return;
        questionData = QuestionDatabase.instance.ReturnQuestionData();
        GettingAnswer();
    }

    public void GettingAnswer()
    {
        foreach (QuestionSO question in questionData)
        {
            foreach(MultipleChoiceData multipleChoice in question.multipleChoiceDatas)
            {
                if (multipleChoice.isAnswer)
                {
                    GameObject x = Instantiate(answerKeyPrefab,answerKeyTransform);
                    x.GetComponent<AnswerKeyPrefab>().SetUpAnswerKeyPrefab(question, maxTime,multipleChoice.AnswerSprite);
                }
            }
        }
    }

    public void StartSearching()
    {
        onSearching = true;
        SoundManager.instance.PlaySFX(SoundManager.instance.phoneTap);
    }
    public void CancelSearching()
    {
        onSearching = false;
        SoundManager.instance.PlaySFX(SoundManager.instance.phoneTap);
    }

    public bool ReturnSearching()
    {
        return onSearching;
    }
}
