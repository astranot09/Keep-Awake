using UnityEngine;

public class PaperScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        TaskManager.instance.OpenTask();
    }
}
