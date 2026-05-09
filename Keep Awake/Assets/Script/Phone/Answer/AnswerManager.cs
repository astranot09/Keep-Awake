
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public static AnswerManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private List<QuestionSO> questionData;

    [SerializeField] private GameObject answerKeyPrefab;
    
    public void GettingAnswer()
    {
        foreach (QuestionSO question in questionData)
        {
            foreach(MultipleChoiceData multipleChoice in question.multipleChoiceDatas)
            {
                if (multipleChoice.isAnswer)
                {
                    Instantiate(answerKeyPrefab);
                }
            }
        }
    }



}
