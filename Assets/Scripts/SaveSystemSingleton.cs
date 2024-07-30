using System;
using UnityEngine;

public class SaveSystemSingleton : MonoBehaviour
{
    public static SaveSystemSingleton Instance { get; private set; }

    [Serializable]
    private struct PlayerSaveData
    {
        public bool hasGame;
        /// <summary>
        /// The scene that the player has YET AKA CURRENTLY left to pass
        /// </summary>
        public string currentSceneName;
    }

    [Serializable]
    private struct GameSettings
    {
        public float musicVolume;
        public float sfxVolume;
    }

    [SerializeField] private PlayerSaveData playerSaveData;
    [SerializeField] private GameSettings gameSettings;
    public string CurrentSceneName => playerSaveData.currentSceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerSaveData = ES3.Load("playerSaveData", new PlayerSaveData());
        if (ES3.KeyExists("gameSettings"))
        {
            gameSettings = ES3.Load("gameSettings", new GameSettings());
        }
        else
        {
            gameSettings = new GameSettings
            {
                musicVolume = 0.1f,
                sfxVolume = 0.1f
            };
            ES3.Save("gameSettings", gameSettings);
        }

    }
    
    public bool HasGame()
    {
        return playerSaveData.hasGame;
    }
    
    public void ResetGame()
    {
        playerSaveData = new PlayerSaveData
        {
            hasGame = true,
            currentSceneName = "TutorialScene"
        };
        ES3.Save("playerSaveData", playerSaveData);
    }

    public void UpdateCurrentScene(string newScene)
    {
        playerSaveData.currentSceneName = newScene;
        ES3.Save("playerSaveData", playerSaveData);
    }
    
    public void SaveGameSettings(float musicVolume, float sfxVolume)
    {
        gameSettings.musicVolume = musicVolume;
        gameSettings.sfxVolume = sfxVolume;
        ES3.Save("gameSettings", gameSettings);
    }
}
