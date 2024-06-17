using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance;
    [Header("CountText")]
    public TextMeshProUGUI countText;
    [Header("GameUI")]
    public GameObject GameUI;
    [Header("HeadQuarter")]
    public int maxHealth = 50000;
    public int curHealth;
    public int money;


    private LevelSO gameLevelSO;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        curHealth = maxHealth;
        StartCoroutine(CountDown());
    }
    private void Update()
    {
        if (curHealth<=0)
        {
            Application.Quit();
        }
    }
    IEnumerator CountDown()
    {
        countText.text = "3";
        yield return new WaitForSeconds(1);
        countText.text = "2";
        yield return new WaitForSeconds(1);
        countText.text = "1";
        yield return new WaitForSeconds(1);
        countText.text = "START!";
        GameUI.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(countText);
    }
}
