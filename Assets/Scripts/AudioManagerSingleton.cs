using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip mainMenuBGM;
    public AudioClip gnomeWoo;
    public AudioClip clickFX;
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
        SaveSettings();
    }
    
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        SaveSettings();
    }

    public static void PlayClickFX()
    {
        if (Instance)
        {
            Instance.sfxSource.PlayOneShot(Instance.clickFX);
            
        }
    }

    private void SaveSettings()
    {
        SaveSystemSingleton.Instance.SaveGameSettings(bgmSource.volume, sfxSource.volume);
    }
}
