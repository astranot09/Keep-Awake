using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private int score;
    [SerializeField] private float time;

    public static Action OnStart;


    private void Start()
    {
        //Sementara
        GameStart();
    }

    public void AddScore(int x)
    {
        score += (x*10);
    }

    public void AddTime(int x)
    {
        score += (x * 10);
    }

    public void Finish()
    {
        time = TimerManager.instance.ReturnTime();
        TaskManager.instance.SubmitAnswer();
        UIManager.instance.FinishSetUp(score,time);
    }

    public void GameStart()
    {
        OnStart?.Invoke();
    }

}
