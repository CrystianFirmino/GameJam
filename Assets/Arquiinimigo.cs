using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Arquiinimigo : MonoBehaviour
{
    public int vida = 10;
    int count = 0;

    float balaTime;
    public GameObject bullet;

    void Update()
    {
        if (count >= vida)
            Destroy(gameObject);
        if (Random.Range(0, 50) == 2 & Time.time - balaTime >= 1 / 2)
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