using UnityEngine;
using UnityEngine.Playables;
public class AwakeBar : MonoBehaviour
{

    public static AwakeBar instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private float currTime;
    [SerializeField] private float maxTime;

    private bool isRunning = false;


    [Header("Timeline")]
    [SerializeField] private PlayableDirector sleepTimeline;
    [SerializeField] private CanvasGroup canvasGroup; 


    private void OnEnable()
    {
        GameManager.OnStart += SetUpAwakeBar;
        canvasGroup.alpha = 0f;
    }
    private void OnDisable()
    {
        GameManager.OnStart -= SetUpAwakeBar;
    }
    private void SetUpAwakeBar()
    {
        currTime = maxTime;
        isRunning = true;
        canvasGroup.alpha = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (currTime > 0)
            {
                currTime -= Time.deltaTime;
            }
            else
            {
                isRunning = false;
                currTime = 0;
                TimelineManager.instance.PlayTimeline(sleepTimeline);
            }
            UIManager.instance.UpdateAwakeBarUI(currTime, maxTime);
        }
    }

    public void AddAwake(float x)
    {
        currTime += Time.deltaTime * x;
        if(currTime>maxTime)
            currTime = maxTime;
    }
    public void MinesAwake(float x)
    {
        currTime -= Time.deltaTime * x;
    }

    public void AddAwakeInstan(float x)
    {
        currTime +=  x;
        if (currTime > maxTime)
            currTime = maxTime;
    }
    public void MinesAwakeInstan(float x)
    {
        currTime -= x;
        if (currTime <= 0)
            currTime = 0.5f;
    }
}
