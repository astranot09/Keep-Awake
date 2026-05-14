using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.phoneTap);
        GameManager.instance.GameStart();
    }
    public void RestartGame()
    {
        SceneController.instance.RestartGame();
    }
    public void ExitGame()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.phoneTap);
        SceneController.instance.Exit();
    }
}
