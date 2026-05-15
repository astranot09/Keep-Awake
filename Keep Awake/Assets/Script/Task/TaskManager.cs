using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{

    public static TaskManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    private void OnEnable()
    {
        GameManager.OnStart += SetUpTask;
        LecturerScript.LectureAngry += CloseTask;
    }

    private void OnDisable()
    {
        GameManager.OnStart -= SetUpTask;
        LecturerScript.LectureAngry -= CloseTask;
    }

    [SerializeField] private GameObject taskPanel;

    [Header("Data")]
    [SerializeField] private List<QuestionSO> questionData;
    bool alreadySetUp;

    [Header("Panel")]
    [SerializeField] private GameObject taskPrefab;
    [SerializeField] private Transform taskTransform;

    [Header("ListJawaban")]
    [SerializeField] private List<TaskPrefab> finalAnswerScript;
    [SerializeField] private RectTransform contentParent;

    public void SetUpTask()
    {
        if (alreadySetUp) return;
        alreadySetUp = true;
        questionData = QuestionDatabase.instance.ReturnQuestionData();
        OpenTaskWithoutSound();
        SpawnTask();
        CloseTask();
    }

    public void SpawnTask()
    {
        foreach(QuestionSO question in questionData)
        {
            GameObject x = Instantiate(taskPrefab,taskTransform);
            x.GetComponent<TaskPrefab>().SetUp(question);
            LayoutRebuilder.ForceRebuildLayoutImmediate(contentParent);
            finalAnswerScript.Add(x.GetComponent<TaskPrefab>());
        }
    }

    public void OpenTaskWithoutSound()
    {
        if (Player.instance.ReturnOpenUI() && !taskPanel.activeSelf) return;
        else if (!taskPanel.activeSelf)
        {
            taskPanel.SetActive(true);
            Player.instance.OpenUI();
        }

        SetUpTask();
    }
    public void OpenTask()
    {
        if (Player.instance.ReturnOpenUI() && !taskPanel.activeSelf) return;
        else if (!taskPanel.activeSelf)
        {
            SoundManager.instance.PlaySFX(SoundManager.instance.pickUpPaper);
            taskPanel.SetActive(true);
            Player.instance.OpenUI();
        }

        SetUpTask();
    }


    public void CloseTask()
    {
        if (Player.instance.ReturnOpenUI() && !taskPanel.activeSelf) return;
        if (taskPanel.activeSelf)
        {
            taskPanel.SetActive(false);
            Player.instance.CloseUI();
        }
        SetUpTask();
    }

    public void SubmitAnswer()
    {
        foreach(TaskPrefab x in finalAnswerScript)
        {
            if (x.isCorrect)
            {
                GameManager.instance.AddScore(1);
            }
        }
    }


}
