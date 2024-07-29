using UnityEngine;

namespace SceneManagers
{
    public class TutorialSceneManager : MonoBehaviour
    {
        public HUDController hud;
        // Start is called before the first frame update
        void Start()
        {
            SaveSystemSingleton.Instance.UpdateCurrentScene("TutorialScene");
            hud.ShowDialog();
        }
    }
}
