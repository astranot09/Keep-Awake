using UnityEngine;

public class DoomScrollingScript : MonoBehaviour
{
    [SerializeField] private bool isDoomScrolling = false;


    [SerializeField] private float addAwake = 2;
    void Update()
    {
        if (isDoomScrolling)
        {
            AwakeBar.instance.AddAwake(addAwake);
        }
    }

    public void DoomScrolling()
    {
        isDoomScrolling = true;
        TimerManager.instance.SpeedUp(2);
    }

    public void CloseDoomScrolling()
    {
        isDoomScrolling = false;
        TimerManager.instance.BackNormal();
    }
}
