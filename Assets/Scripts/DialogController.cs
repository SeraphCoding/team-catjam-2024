using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attach this script to the Dialog GameObject that holds the avatar and text.
/// </summary>
public class DialogController : MonoBehaviour
{
    /// <summary>
    /// Whether the dialog is currently hidden or not.
    /// </summary>
    public bool showDialog;
    
    /// <summary>
    /// A list of dialog to display to the player.
    /// </summary>
    public List<string> dialog;
    /// <summary>
    /// Avatar corresponding to the list of dialog to show. 
    /// </summary>
    public List<Sprite> avatars;
    /// <summary>
    /// The current text to display.
    /// </summary>
    public TextMeshProUGUI textGameObject;
    /// <summary>
    /// Avatar GameObject of the character speaking
    /// </summary>
    public Image avatarGameObject;
    private int _currentIndex = 0;
    
    public delegate void DialogFinishedHandler();
    public event DialogFinishedHandler OnDialogFinished;
    

    // Update is called once per frame
    void Update()
    {
        
        gameObject.SetActive(showDialog);
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
            _currentIndex++;
        }
        if (_currentIndex >= dialog.Count || dialog.Count== 0) {
            showDialog = false;
            _currentIndex = 0;
            OnDialogFinished?.Invoke();
        }
        else
        {
            textGameObject.SetText(dialog[_currentIndex]);
            avatarGameObject.sprite = avatars[_currentIndex];
        }

    }
}
