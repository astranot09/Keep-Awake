

using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    [SerializeField] private Button answerButton;
    [SerializeField] private Image answerImage;

    private Color defaultColor = Color.white;
    private Color selectedColor = Color.grey;

    private TaskPrefab taskPrefab;

    public bool isCorrect;

    public void SetUp(bool x, Sprite y, TaskPrefab parent)
    {
        isCorrect = x;

        taskPrefab = parent;

        answerImage.sprite = y;

        answerButton.onClick.RemoveAllListeners();
        answerButton.onClick.AddListener(SelectAnswer);
    }

    public void SelectAnswer()
    {
        taskPrefab.SelectAnswer(this);
    }

    public void Select()
    {
        answerImage.color = selectedColor;
    }

    public void Deselect()
    {
        answerImage.color = defaultColor;
    }
}