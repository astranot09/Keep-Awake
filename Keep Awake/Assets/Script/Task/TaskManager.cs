using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    [SerializeField] private GameObject taskPanel;

    [Header("Data")]
    [SerializeField] private List<QuestionSO> questionData;
    bool alreadySetUp;

    [Header("Panel")]
    [SerializeField] private GameObject taskPrefab;
    [SerializeField] private Transform taskTransform;

    public void SetUp()
    {
        if (alreadySetUp) return;
        alreadySetUp = true;
        questionData = QuestionDatabase.instance.ReturnQuestionData();
        SpawnTask();
    }

    public void SpawnTask()
    {
        foreach(QuestionSO question in questionData)
        {
            GameObject x = Instantiate(taskPrefab,taskTransform);
            x.GetComponent<TaskPrefab>().SetUp(question);
        }
    }


    public void OpenTask()
    {
        taskPanel.SetActive(!taskPanel.activeSelf);
        SetUp();
    }


}
