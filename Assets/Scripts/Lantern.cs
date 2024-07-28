
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
        if (!lanternLight2D.gameObject.activeSelf && !canBeTurnedBackOn) return;
        lanternLight2D.gameObject.SetActive(!lanternLight2D.gameObject.activeSelf);
        GetComponent<SpriteRenderer>().sprite = lanternLight2D.gameObject.activeSelf ? unlitSprite : litSprite;
        
        if (canBeTurnedBackOn) return;
        interactable = false;
    }
}
