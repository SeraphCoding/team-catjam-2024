using UnityEngine;

public class HUDController : MonoBehaviour
{
    public DialogController dialogController;
    public HintController hintController;
    public Player player;

    void Awake()
    {
        dialogController.OnDialogFinished += HideDialog;
    }

    private void Update()
    {
        if (!player) return;
        if (player.Interactable && (player.Interactable.IsInteractable || player.Interactable.isRotatable))
        {
            string hintText = (player.Interactable.IsInteractable ? "F - " + player.Interactable.interactAction : "") + 
                              (player.Interactable.IsInteractable && player.Interactable.isRotatable ? "\n" : "") +
                              (player.Interactable.isRotatable ? "R - " + player.Interactable.rotateAction : "");
            hintController.gameObject.SetActive(true);
            hintController.SetText(hintText);
        }
        else
        {
            if (player.Interactable && player.Interactable.noAction != null)
            {
                hintController.gameObject.SetActive(true);
                hintController.SetText(player.Interactable.noAction);
            }
            else
            {
                hintController.gameObject.SetActive(false);
            }
        }
    }

    public void ShowDialog()
    {
        player.FreezePlayer = true;
        dialogController.gameObject.SetActive(true);
        dialogController.showDialog = true;
    }
    
    public void HideDialog()
    {
        player.FreezePlayer = false;
        dialogController.gameObject.SetActive(false);
    }
}
