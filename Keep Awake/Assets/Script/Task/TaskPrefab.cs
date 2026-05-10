using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskPrefab : MonoBehaviour
{

    [SerializeField] private QuestionSO data;

    [SerializeField] private TMP_Text title;

    [Header("Question")]
    [SerializeField] private Image question;

    [Header("Answer")]
    [SerializeField] private GameObject answerPrefab;
    [SerializeField] private Transform answerTransform;


    public void SetUp(QuestionSO questionSO)
    {
        data = questionSO;
        SpawnTask();
    }

    public void SpawnTask()
    {
        title.text = data.name;
        question.sprite = data.questionSprite;
        foreach (MultipleChoiceData multipleChoice in data.multipleChoiceDatas)
        {
            GameObject y = Instantiate(answerPrefab, answerTransform);
            y.GetComponent<AnswerScript>().SetUp(multipleChoice.isAnswer, multipleChoice.AnswerSprite);
        }
            
    }
}
