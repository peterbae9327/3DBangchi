using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float health;
    public float speed;
    private Rigidbody rb;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void LateUpdate()
    {
        Look(transform.position.normalized);
    }
    public void SetStat(float _health, float _speed)
    {
        health = _health;
        speed = _speed;
    }
    public void SubtrackHealth(float power)
    {
        health = Mathf.Max(health - power, 0);
        if(health == 0)
        {
            animator.SetTrigger("OnDeath");
            Invoke("Die", 1f);
        }
    }
    private void Look(Vector3 direction)
    {
        float rotY = Mathf.Atan2(direction.x, -direction.z) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -rotY, 0);
    }
    private void Move()
    {
        rb.velocity = transform.forward * speed;
        animator.SetBool("OnMove", true);
    }
    private void Die()
    {
        Destroy(gameObject);
    }

}
