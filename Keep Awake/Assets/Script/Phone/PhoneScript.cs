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
    [SerializeField] private SpriteRenderer phoneRenderer;

    [SerializeField] private DoomScrollingScript doomScrollingScript;


    private bool openSetting;

    private void Awake()
    {
        GameManager.OnStart += PhoneSpawn;
        LecturerScript.LectureAngry += PhoneClose;
        // awal invisible
        phoneRenderer.enabled = false;
    }

    private void OnDestroy()
    {
        GameManager.OnStart -= PhoneSpawn;
        LecturerScript.LectureAngry -= PhoneClose;
    }

    public void OpenScrolling()
    {
        OpenPanel(scrollingPanel);
    }

    public void OpenInternet()
    {
        OpenPanel(internetPanel);
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
    public void PhoneOpen()
    {
        if (!GameManager.instance.onGame) return;
        if (Player.instance.ReturnOpenUI() && !phonePanel.activeSelf) return;

        if (!phonePanel.activeSelf)
        {
            phonePanel.SetActive(true);
            if (openSetting)
            {
                openSetting = false;
                settingPanel.SetActive(true);
            }
            if (scrollingPanel.activeSelf)
            {
                doomScrollingScript.DoomScrolling();
            }
            Player.instance.OpenUI();
            Player.instance.NotConcetrate();
            phoneRenderer.enabled = false;
        }
    }

    public void PhoneClose()
    {
        if (!GameManager.instance.onGame) return;
        if (Player.instance.ReturnOpenUI() && !phonePanel.activeSelf) return;
        if (phonePanel.activeSelf)
        {
            phonePanel.SetActive(false);
            if (settingPanel.activeSelf)
            {
                openSetting = true;
                settingPanel.SetActive(false);
            }
            if (scrollingPanel.activeSelf)
            {
                doomScrollingScript.CloseDoomScrolling();
            }
            Player.instance.CloseUI();
            Player.instance.OnConcetrate();
            phoneRenderer.enabled = true;
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


    public void PhoneSpawn()
    {
        phoneRenderer.enabled = true;
    }





    private void OnMouseDown()
    {
        PhoneOpen();
    }

}
