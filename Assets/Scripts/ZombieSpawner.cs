using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public List<Vector3> spawnPoses = new List<Vector3>();
    public LevelSO levelSO;
    public GameObject zombiePrefab;
    public float zombieTimes;
    private void Awake()
    {
        levelSO = GameObject.Find("GameManager").GetComponent<GameManager>().levelSO;
        zombieTimes = levelSO.zombieTimes;
    }
    public void GetStarted()
    {
        StartCoroutine(SpawnZombie());
    }
    IEnumerator SpawnZombie()
    {
        while (true)
        {
            GameObject go = Instantiate(zombiePrefab,transform);
            go.transform.position = spawnPoses[Random.Range(0, spawnPoses.Count)];
            go.GetComponent<ZombieMovement>().SetStat(levelSO.zombieHealth,levelSO.zombieSpeed);
            yield return new WaitForSeconds(zombieTimes);
        }
    }
}
