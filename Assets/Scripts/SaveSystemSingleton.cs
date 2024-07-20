using System;
using UnityEngine;

public class SaveSystemSingleton : MonoBehaviour
{
    public static SaveSystemSingleton Instance { get; private set; }

    [Serializable]
    private struct PlayerSaveData
    {
        public bool hasGame;
    }

    [SerializeField] private PlayerSaveData playerSaveData;

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
    }
    
    public bool HasGame()
    {
        return playerSaveData.hasGame;
    }
    
    public void ResetGame()
    {
        playerSaveData = new PlayerSaveData
        {
            hasGame = true
        };
        ES3.Save("playerSaveData", playerSaveData);
    }
}
