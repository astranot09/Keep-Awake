using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject homePagePanel;
    [SerializeField] private GameObject scrollingPanel;
    [SerializeField] private GameObject internetPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject mainMenuPanel;

    [Header("Phone")]
    [SerializeField] private GameObject phonePanel;

    private void Start()
    {
        OpenPanel(homePagePanel);
    }

    public void OpenScrolling()
    {
        OpenPanel(scrollingPanel);
    }

    public void OpenInternet()
    {
        OpenPanel(internetPanel);
        AnswerKeyManager.instance.SetUp();
    }

    public void OpenSetting()
    {
        OpenPanel(settingPanel);
    }

    public void OpenMainMenu()
    {
        OpenPanel(mainMenuPanel);
    }

    public void OpenHomePage()
    {
        OpenPanel(homePagePanel);
    }
    public void Phone()
    {
        phonePanel.SetActive(!phonePanel.activeSelf);
    }


    private void OpenPanel(GameObject targetPanel)
    {
        // matiin semua panel
        homePagePanel.SetActive(false);
        scrollingPanel.SetActive(false);
        internetPanel.SetActive(false);
        settingPanel.SetActive(false);
        mainMenuPanel.SetActive(false);

        // nyalain target
        targetPanel.SetActive(true);
    }
}
