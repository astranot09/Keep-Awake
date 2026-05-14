using UnityEngine;
using UnityEngine.Playables;

public class ButtonManager : MonoBehaviour
{

    public void StartGame()
    {
        MainMenuScript.instance.PlayTimeline();
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
