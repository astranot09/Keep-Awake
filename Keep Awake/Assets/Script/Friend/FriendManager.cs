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

    private void Start()
    {
        ResetTrigger();
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
            Debug.Log("Dapet Item");
        }
        else
        {
            Debug.Log("Zonk");
        }
    }
}