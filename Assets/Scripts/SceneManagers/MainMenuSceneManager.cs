using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace SceneManagers
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        [SerializeField] private Button loadGameButton;

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
            loadGameButton.interactable = SaveSystemSingleton.Instance.HasGame();
        }

        // Not implemented yet - this is just to test the save system 
        public void CreateNewGame()
        {
            SaveSystemSingleton.Instance.ResetGame();
        }


    }
}
