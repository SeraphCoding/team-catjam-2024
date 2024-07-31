using UnityEngine;

namespace SceneManagers
{
    public class LevelSceneManager : MonoBehaviour
    {
        public HUDController hud;
        public bool dialog = true;
        public string sceneName;
        // Start is called before the first frame update
        void Start()
        {
            if (SaveSystemSingleton.Instance)
            {
                SaveSystemSingleton.Instance.UpdateCurrentScene(sceneName);
            }
            if (dialog) hud.ShowDialog();
        }
    }
}
