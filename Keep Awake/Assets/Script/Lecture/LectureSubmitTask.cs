using UnityEngine;

public class LectureSubmitTask : MonoBehaviour
{

    private void OnMouseDown()
    {
        UIManager.instance.OpenSubmitPanel();
    }

    public void SubmitAnswer()
    {
        //TaskManager.instance.SubmitAnswer();
        GameManager.instance.Finish();
    }
}
