using UnityEngine;
using Button = UnityEngine.UI.Button;

public class MainMenuSceneManager : MonoBehaviour
{
    private SaveSystemSingleton _saveSystemSingleton = SaveSystemSingleton.Instance;
    [SerializeField] private Button loadGameButton;

    private void Awake()
    {
        if (_saveSystemSingleton == null)
        {
           _saveSystemSingleton = SaveSystemSingleton.Instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CheckForExistingGame();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForExistingGame();
    }
    
    private void CheckForExistingGame()
    {
        loadGameButton.interactable = _saveSystemSingleton.HasGame();
    }

    // Not implemented yet - this is just to test the save system 
    public void CreateNewGame()
    {
        _saveSystemSingleton.ResetGame();
    }


}
