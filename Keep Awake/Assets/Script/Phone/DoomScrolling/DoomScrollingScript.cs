using UnityEngine;

public class DoomScrollingScript : MonoBehaviour
{
    [SerializeField] private bool isDoomScrolling = false;


    [SerializeField] private float addAwake = 2;
    [SerializeField] private float speedUp = 2;


    [SerializeField] private ScrollingContentButton scrollingContent;

    private void OnEnable()
    {
        LecturerScript.LectureAngry += CloseDoomScrolling;
    }
    private void OnDisable()
    {
        LecturerScript.LectureAngry -= CloseDoomScrolling;
    }
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
        TimerManager.instance.SpeedUp(speedUp);
    }

    public void CloseDoomScrolling()
    {
        isDoomScrolling = false;
        TimerManager.instance.BackNormal();
        scrollingContent.StartIndex();
    }
}
