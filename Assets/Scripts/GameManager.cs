using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelSO levelSO;

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GetLevelSO(LevelSO _levelSO)
    {
        levelSO = _levelSO;
    }
    public LevelSO LoadLevelSO()
    {
        return levelSO;
    }
}
