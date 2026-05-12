using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public bool isTalking = false;

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
    }
    private void OnDisable()
    {
        GameManager.OnStart -= ResetTrigger;
    }

    private void Update()
    {
        if (!isTalking) return;

        AwakeBar.instance.AddAwake(2);

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
    }
    public void StopTalking()
    {
        isTalking = false;
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