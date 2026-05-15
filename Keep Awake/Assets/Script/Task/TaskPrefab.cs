using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TaskPrefab : MonoBehaviour
{
    [SerializeField] private QuestionSO data;

    [SerializeField] private TMP_Text title;

    [Header("Question")]
    [SerializeField] private Image question;

    [Header("Answer")]
    [SerializeField] private GameObject answerPrefab;
    [SerializeField] private Transform answerTransform;

    private List<AnswerScript> answers = new();

    private AnswerScript currentSelected;

    public bool isCorrect = false;
    [SerializeField] private RectTransform contentParent;
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

            AnswerScript answer =
                y.GetComponent<AnswerScript>();

            answer.SetUp(
                multipleChoice.isAnswer,
                multipleChoice.AnswerSprite,
                this
            );
            LayoutRebuilder.ForceRebuildLayoutImmediate(contentParent);
            answers.Add(answer);
        }
    }

    public void SelectAnswer(AnswerScript selected)
    {
        // reset semua
        foreach (AnswerScript answer in answers)
        {
            answer.Deselect();
        }
        SoundManager.instance.PlaySFX(SoundManager.instance.pencil);
        // pilih baru
        selected.Select();

        currentSelected = selected;

        if (currentSelected.isCorrect)
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }

        Debug.Log(selected.isCorrect ? "Benar" : "Salah");
    }
}