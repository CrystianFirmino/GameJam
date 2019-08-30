using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Arquiinimigo : MonoBehaviour
{
    public int vida = 3;
    public GameObject bullet;

    int hitCount = 0;

    float balaTime;

    void Update()
    {
        if (hitCount >= vida)
            Destroy(gameObject);
        if (Random.Range(0, 100) == 2 & Time.time - balaTime >= 1)
            AttackL();
        else if (Random.Range(0, 100) == 4 & Time.time - balaTime >= 1)
            AttackH();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            hitCount += 1;
        }
    }

    public void AttackL()
    {
        //atack
        Instantiate(bullet, transform.position + (Vector3.left) + (Vector3.down* 4/6), Quaternion.identity);
        balaTime = Time.time;
    }
    public void AttackH()
    {
        //atack
        Instantiate(bullet, transform.position + (Vector3.left) + (Vector3.up*4/6), Quaternion.identity);
        balaTime = Time.time;

    }
}