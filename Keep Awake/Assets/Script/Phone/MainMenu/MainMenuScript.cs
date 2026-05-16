using UnityEngine;
using UnityEngine.Playables;

public class MainMenuScript : MonoBehaviour
{


    public static MainMenuScript instance;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private PlayableDirector openingTimeline;

    //[SerializeField] private GameObject mainMenuPanel;
    //[SerializeField] private GameObject settingPanel;


    public void PlayTimeline()
    {
        TimelineManager.instance.PlayTimeline(openingTimeline);
    }

    //public void OpenSetting()
    //{
    //    mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
    //    settingPanel.SetActive(!settingPanel.activeSelf);
    //}
}
