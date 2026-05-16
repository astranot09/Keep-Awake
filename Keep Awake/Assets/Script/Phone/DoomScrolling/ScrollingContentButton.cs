using UnityEngine;

public class ScrollingContentButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    int index = 1;

    public void ChangeContent()
    {
        Debug.Log("ganti");
        index++;
        if(index > 3)
        {
            index = 1;
            
        }
        _animator.SetInteger("index", index);
    }

    public void StartIndex()
    {
        index = 1;
    }

}
