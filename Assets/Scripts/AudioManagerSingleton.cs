using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip mainMenuBGM;
    public AudioClip gnomeWoo;
    public AudioClip catWalking;
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



    private void SaveSettings()
    {
        SaveSystemSingleton.Instance.SaveGameSettings(bgmSource.volume, sfxSource.volume);
    }
    
    public static void PlayClickFX()
    {
        if (Instance)
        {
            Instance.sfxSource.PlayOneShot(Instance.clickFX);
            
        }
    }
    
    public static void CatWalk(bool isWalking)
    {
        if (!Instance) return;
        if (Instance.sfxSource.isPlaying && Instance.sfxSource.clip == Instance.catWalking && !isWalking)
        {
           Instance.sfxSource.Pause();
        }
        if (!Instance.sfxSource.isPlaying && Instance.sfxSource.clip == Instance.catWalking && isWalking)
        {
            Instance.sfxSource.UnPause();
        }
        if (Instance.sfxSource.clip != Instance.catWalking && isWalking)
        {
            Instance.sfxSource.clip = Instance.catWalking;
            Instance.sfxSource.loop = true;
            Instance.sfxSource.Play();
        }
            
    }
}
