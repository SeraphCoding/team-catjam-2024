
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern : Interactable
{
    [SerializeField]
    public Light2D lanternLight2D;
    public Sprite unlitSprite;
    // Setting the lit sprite specifically because doing so in awake will cause the default sprite to be the unlit one.
    public Sprite litSprite;

    protected override void OnSetTransform()
    {
        TargetTransform = lanternLight2D.transform;
    }
    
    
    public bool canBeTurnedBackOn;
    public override void Interact()
    {
        base.Interact();
        if ((!lanternLight2D.gameObject.activeSelf && !canBeTurnedBackOn) || !interactable) return;
        lanternLight2D.gameObject.SetActive(!lanternLight2D.gameObject.activeSelf);
        if (!lanternLight2D.gameObject.activeSelf) AudioManager.PlayTurnOffLampFX(); 
        GetComponent<SpriteRenderer>().sprite = lanternLight2D.gameObject.activeSelf ? unlitSprite : litSprite;
        
        if (canBeTurnedBackOn) return;
        interactable = false;
    }

    // Enables rotation and interaction when powered or disables them when unpowered.
    public void ToggleLanternPower(bool powered)
    {
        if (!interactable && !isRotatable && powered)
        {
            // play the powered audio once when you get powered
            AudioManager.PlayPowerLampFX();
        }
        isRotatable = powered;
        interactable = powered;
        noAction = powered ? null : "No power!";
        if (lanternLight2D.gameObject.activeSelf && !powered)
        {
            // Turn off the lantern if it isnt powered but currently on, but does not turn it on just because it was powered.
            lanternLight2D.gameObject.SetActive(false);
        } 
        
        GetComponent<SpriteRenderer>().sprite = powered ? litSprite : unlitSprite;
        
    }
}
