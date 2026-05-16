using UnityEngine;

public class FriendManager : MonoBehaviour
{

    public static FriendManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }



    public bool isTalking = false;
    [SerializeField] private float addAwake;
    [Header("Giving Item")]
    [SerializeField] private float minTrigger = 3f;
    [SerializeField] private float maxTrigger = 8f;

    [SerializeField] private float currTrigger;

    [Range(0, 100)]
    [SerializeField] private int gachaRate = 25;

    [SerializeField] private ItemSO item;
    

    private void OnEnable()
    {
        GameManager.OnStart += ResetTrigger;
        LecturerScript.LectureAngry += StopTalking;
    }
    private void OnDisable()
    {
        GameManager.OnStart -= ResetTrigger;
        LecturerScript.LectureAngry -= StopTalking;
    }

    private void Update()
    {
        if (!isTalking) return;

        AwakeBar.instance.AddAwake(addAwake);

        if (currTrigger > 0)
        {
            currTrigger -= Time.deltaTime;
        }
        else
        {
            ResetTrigger();

            GachaSystem();
        }
    }

    private void ResetTrigger()
    {
        currTrigger = Random.Range(minTrigger, maxTrigger);
    }

    public void TalkToFriend()
    {
        ResetTrigger();
        isTalking = true;
        SoundManager.instance.PlayLongSFX(SoundManager.instance.talkingQuiet);
    }
    public void StopTalking()
    {
        isTalking = false;
        SoundManager.instance.StopLongSFX();
    }

    private void GachaSystem()
    {
        int roll = Random.Range(0, 100);

        if (roll < gachaRate)
        {
            InventoryManager.instance.AddItem(item);
            Debug.Log("Dapet Item");
        }
        else
        {
            Debug.Log("Zonk");
        }
    }
}