using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public float power;
    public List<GameObject> zombies = new List<GameObject>();
    public LevelSO levelSO;
    public Animator animator;

    private void Awake()
    {
        levelSO = GameObject.Find("GameManager").GetComponent<GameManager>().levelSO;
        gameObject.TryGetComponent(out animator);
        if (gameObject.tag == "Marine")
        {
            power = levelSO.marinePower;
        }
        else
        {
            power = levelSO.towerPower;
        }
    }
    private void Start()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        if (zombies.Count != 0)
        {
            GameObject target = null;
            float curDistance = 0;
            foreach (GameObject zombie in zombies)
            {
                float distance = (zombie.transform.position - transform.position).sqrMagnitude;
                if (distance < curDistance || curDistance == 0)
                {
                    curDistance = distance;
                    target = zombie;
                }
                else if(zombie == null) zombies.Remove(zombie);
            }
            if(animator != null) animator.SetBool("OnAttack", true);
            target.GetComponent<ZombieMovement>().SubtrackHealth(power);
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            if (animator != null) animator.SetBool("OnAttack", false);
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            zombies.Add(other.gameObject);
        }
    }
}
