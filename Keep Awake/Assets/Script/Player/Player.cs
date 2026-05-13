using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private bool onConcentration = true;

    [SerializeField] private bool onOpenUI;

    public void OnConcetrate()
    {
        onConcentration = true;
    }

    public void NotConcetrate()
    {
        onConcentration = false;
    }
    public bool ReturnConcetrate()
    {
        return onConcentration;
    }

    public void OpenUI()
    {
        onOpenUI = true;
    }

    public void CloseUI()
    {
        onOpenUI = false;
    }

    public bool ReturnOpenUI()
    {
        return onOpenUI;
    }
}