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

    public void toggleShowSliders()
    {
        AudioManager.PlayClickFX();
        bgmSlider.gameObject.SetActive(!bgmSlider.gameObject.activeSelf);
        sfxSlider.gameObject.SetActive(!sfxSlider.gameObject.activeSelf);
    }
}
