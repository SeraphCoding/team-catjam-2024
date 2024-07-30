using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    public void UpdateBGMVolume()
    {
        AudioManager.Instance.SetBGMVolume(bgmSlider.value);
    }
    
    public void UpdateSFXVolume()
    {
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);
    }
}
