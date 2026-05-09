using UnityEngine;
public class AwakeBar : MonoBehaviour
{
    [SerializeField] private float currTime;
    [SerializeField] private float maxTime;

    private bool isRunning = true;
    void Start()
    {
        currTime = maxTime;
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
            }
            UIManager.instance.UpdateAwakeBarUI(currTime, maxTime);
        }
    }

    public void AddAwake()
    {

    }

}
