using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioClip mainMenuBGM;
    public AudioClip gnomeWoo;
    public AudioClip catWalking;
    public AudioClip clickFX;
    public List<AudioClip> turnOffLampFX;
    public AudioClip portalTeleportFX;
    public AudioClip powerLampFX;
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

    private void Start()
    {
        if (!SaveSystemSingleton.Instance) return;
        SaveSystemSingleton.GameSettings gameSettings = SaveSystemSingleton.Instance.GetGameSettings();
        bgmSource.volume = gameSettings.musicVolume;
        sfxSource.volume = gameSettings.sfxVolume;
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

    public static void PlayPowerLampFX()
    {
        if (!Instance) return;
        Instance.sfxSource.clip = null;
        Instance.sfxSource.loop = false;
        Instance.sfxSource.PlayOneShot(Instance.powerLampFX);
    }

    public static void PlayTurnOffLampFX()
    {
        
        if (!Instance) return;
        Instance.sfxSource.clip = null;
        Instance.sfxSource.loop = false;
        int randomIndex = Random.Range(0, Instance.turnOffLampFX.Count);
        Instance.sfxSource.PlayOneShot(Instance.turnOffLampFX[randomIndex]);
    }

    public static void PlayPortalTeleport()
    {
        if (!Instance) return;
        Instance.sfxSource.clip = null;
        Instance.sfxSource.loop = false;
        Instance.sfxSource.PlayOneShot(Instance.portalTeleportFX);
    }
    
    public static void PlayGnome()
    {
        if (!Instance) return;
        Instance.sfxSource.clip = null;
        Instance.sfxSource.loop = false;
        Instance.sfxSource.PlayOneShot(Instance.gnomeWoo);
    }

    public static void StopAllMusic()
    {
        if (!Instance) return;
        Instance.bgmSource.Stop();
        Instance.sfxSource.Stop();
        Instance.sfxSource.clip = null;
        Instance.sfxSource.loop = false;
        Instance.bgmSource.clip = null;
        Instance.bgmSource.loop = false;
    }
}
