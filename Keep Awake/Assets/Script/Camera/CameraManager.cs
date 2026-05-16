using UnityEngine;
using Unity.Cinemachine;
public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Virtual Camera")]
    [SerializeField] private CinemachineCamera cinemachineCamera;

    [Header("Targets")]
    [SerializeField] private Transform scene1;
    [SerializeField] private Transform scene2;

    [Header("ButtonUI")]
    [SerializeField] private GameObject buttonScene1;
    [SerializeField] private GameObject buttonScene2;
    [SerializeField] private CanvasGroup buttonGroup;

    private void OnEnable()
    {
        GameManager.OnStart += FollowScene1;
        GameManager.OnStart += SetUpButton;
        LecturerScript.LectureAngry += FollowScene1;
        buttonGroup.alpha = 0f;
    }

    private void OnDisable()
    {
        GameManager.OnStart -= FollowScene1;
        GameManager.OnStart -= SetUpButton;
        LecturerScript.LectureAngry -= FollowScene1;
    }

    public void FollowScene1()
    {
        Debug.Log("Balik");
        cinemachineCamera.Follow = scene1;
        buttonScene1.SetActive(true);
        buttonScene2.SetActive(false);
        Player.instance.CloseUI();
        Player.instance.OnConcetrate();
        FriendManager.instance.StopTalking();
    }

    public void FollowScene2()
    {
        if(Player.instance.ReturnOpenUI()) return;
        Debug.Log("Ngobrol");
        cinemachineCamera.Follow = scene2;
        buttonScene2.SetActive(true);
        buttonScene1.SetActive(false);
        Player.instance.OpenUI();
        Player.instance.NotConcetrate();
        FriendManager.instance.TalkToFriend();
    }

    public void SetUpButton()
    {
        buttonGroup.alpha = 1f;
    }
}
