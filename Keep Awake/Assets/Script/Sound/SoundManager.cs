using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    [Header("Sound Source")]
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SFX;

    [Header("BGM")]
    public AudioClip bgmSound;

    [Header("SFX")]
    public AudioClip phoneTap;
    public AudioClip pencil;
    public AudioClip zipperOpen;
    public AudioClip zipperClose;

    public AudioClip drinkCofee;
    public AudioClip pickUpPaper;
    public AudioClip tableSlap;

    public AudioClip mad;
    public AudioClip talkingQuiet;

    private void Start()
    {
        PlayBGM(bgmSound);
    }


    public void PlayBGM(AudioClip bgm)
    {
        if (BGM != null)
        {
            BGM.Stop();
        }
        BGM.clip = bgm;
        BGM.Play();
        BGM.loop = true;
    }
    public void PlaySFX(AudioClip sfx)
    {
        SFX.PlayOneShot(sfx);
    }
    public void PlayLongSFX(AudioClip sfx)
    {
        SFX.clip = sfx;
        SFX.Play();
        SFX.loop = true;
    }
    public void StopLongSFX()
    {
        if (SFX != null)
        {
            SFX.Stop();
        }
    }
}
