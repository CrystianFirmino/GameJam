using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Arquiinimigo : MonoBehaviour
{
    int count = 0;

    float balaTime;
    public GameObject bullet;

    void Start()
    {

    }

    void Update()
    {
        if (count >= 3)
            Destroy(gameObject);
        if (Random.Range(0, 100) == 2 & Time.time - balaTime >= 1 / 2)
            Attack();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            count += 1;
        }
    }

    public void Attack()
    {
        //atack
        Instantiate(bullet, transform.position + (Vector3.left), Quaternion.identity);
        balaTime = Time.time;
    }
}