using System.Collections.Generic;
using UnityEngine;

public class QuestionDatabase : MonoBehaviour
{
    public static QuestionDatabase instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Data")]
    [SerializeField] private List<QuestionSO> questionData;



    public List<QuestionSO> ReturnQuestionData()
    {
        return questionData;
    }
}
