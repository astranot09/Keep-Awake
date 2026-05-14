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
        if (!GameManager.instance.onGame) return;
        if (Player.instance.ReturnOpenUI() && !phonePanel.activeSelf) return;

        if (phonePanel.activeSelf)
        {
            phonePanel.SetActive(false);
            Player.instance.CloseUI();
            Player.instance.OnConcetrate();
        }
        else if (!phonePanel.activeSelf)
        {
            phonePanel.SetActive(true);
            Player.instance.OpenUI();
            Player.instance.NotConcetrate();
        }
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
        SoundManager.instance.PlaySFX(SoundManager.instance.phoneTap);
    }








    private void OnMouseDown()
    {
        Phone();
    }

}
