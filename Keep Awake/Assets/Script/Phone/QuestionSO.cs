using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MultipleChoiceData
{
    public Sprite AnswerSprite;
    public bool isAnswer;
}


[CreateAssetMenu(fileName = "QuestionSO", menuName = "Scriptable Objects/QuestionSO")]
public class QuestionSO : ScriptableObject
{
    public string questionName;
    public Sprite questionSprite;
    public List<MultipleChoiceData> multipleChoiceDatas;
}
