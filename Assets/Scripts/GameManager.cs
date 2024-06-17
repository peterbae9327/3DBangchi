using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelSO levelSO;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
