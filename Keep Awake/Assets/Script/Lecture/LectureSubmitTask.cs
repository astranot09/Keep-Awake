using UnityEngine;

public class LectureSubmitTask : MonoBehaviour
{
    private void OnMouseDown()
    {
        TaskManager.instance.SubmitAnswer();
    }
}
