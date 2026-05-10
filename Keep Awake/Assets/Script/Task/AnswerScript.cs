using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class AnswerScript : MonoBehaviour
{
    [SerializeField] private Button answerButton;
    [SerializeField] private Image answerImage;

    public void SetUp(bool x, Sprite y)
    {
        answerImage.sprite = y;
        answerButton.onClick.RemoveAllListeners();
        if (x)
            answerButton.onClick.AddListener(CorrectAnswer);
        else
            answerButton.onClick.AddListener(WrongAnswer);
    }

    public void CorrectAnswer()
    {
        Debug.Log("Bener");
        answerImage.color = Color.grey;
    }

    public void WrongAnswer()
    {
        Debug.Log("Salah");
        answerImage.color = Color.grey;
    }
}
