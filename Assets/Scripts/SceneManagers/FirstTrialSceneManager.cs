using UnityEngine;

namespace SceneManagers
{
    public class FirstTrialSceneManager : MonoBehaviour
    {
        public HUDController hud;
        // Start is called before the first frame update
        void Start()
        {
            hud.ShowDialog();
        }
    }
}
