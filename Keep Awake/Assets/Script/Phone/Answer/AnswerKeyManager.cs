
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

    [Header("Spawning")]
    [SerializeField] private GameObject answerKeyPrefab;
    [SerializeField] private Transform answerKeyTransform;

    [Header("Searching")]
    [SerializeField] private bool onSearching;

    public void GettingAnswer()
    {
        foreach (QuestionSO question in questionData)
        {
            foreach(MultipleChoiceData multipleChoice in question.multipleChoiceDatas)
            {
                if (multipleChoice.isAnswer)
                {
                    Instantiate(answerKeyPrefab,answerKeyTransform);
                }
            }
        }
    }

    public void OnSearching()
    {
        onSearching = true;
    }
    public void CancelSearching()
    {
        onSearching = false;
    }
}
