using UnityEngine;
using UnityEngine.UI;
public class QuestionScript : MonoBehaviour
{
    [SerializeField] private Image questionImage;
    
    public void SetUp(Sprite x)
    {
        questionImage.sprite = x;
    }
}
