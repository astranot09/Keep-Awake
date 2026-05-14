using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;


    [SerializeField] private Slider MasterSlider;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;


    public void Start()
    {

        if (PlayerPrefs.HasKey("Master"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }


    }
    private void SetVolume()
    {
        SetMasterVolume();
        SetBGMVolume();
        SetSFXVolume();
    }

    public void SetMasterVolume()
    {
        float volume = MasterSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume)*20);
    }
    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }


    private void LoadVolume()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("Master");
        BGMSlider.value = PlayerPrefs.GetFloat("BGM");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");

        SetMasterVolume();
        SetBGMVolume();
        SetSFXVolume();
    }


}
