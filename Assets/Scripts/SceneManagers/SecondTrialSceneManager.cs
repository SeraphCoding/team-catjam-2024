using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagers
{
    public class SecondTrialSceneManager : MonoBehaviour
    {
        public HUDController hud;
        // Start is called before the first frame update
        void Start()
        {
            //SaveSystemSingleton.Instance.UpdateCurrentScene("SecondTrialScene");
            hud.ShowDialog();
        }
    }
}
