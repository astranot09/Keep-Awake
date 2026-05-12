using UnityEngine;

public class TimerManager : MonoBehaviour
{

    public static TimerManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private float currTime;
    [SerializeField] private float maxTime;

    [SerializeField] private float speedTime = 1f;

    private bool isRunning = false;


    
    private void OnEnable()
    {
        GameManager.OnStart += SetUpTimer;
    }
    private void OnDisable()
    {
        GameManager.OnStart -= SetUpTimer;
    }

    void SetUpTimer()
    {
        currTime = maxTime;
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (currTime > 0)
            {
                currTime -= (Time.deltaTime * speedTime);
            }
            else
            {
                isRunning = false;
                currTime = 0;
                GameManager.instance.Finish();
            }
            UIManager.instance.UpdateTimerUI(currTime);
        }
    }


    public void SpeedUp(float speed)
    {
        speedTime *= speed;
    }
    public void BackNormal()
    {
        speedTime = 1f;
    }

    public float ReturnTime()
    {
        isRunning = false;
        return currTime;
    }
}
