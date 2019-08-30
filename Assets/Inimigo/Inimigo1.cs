using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{
    public int vida = 3;
    public int freqTiros = 100;
    public GameObject bullet;
    public GameObject player;

    int hitCount = 0;

    float balaTime;

    void Update()
    {
        if (transform.position.x - player.transform.position.x < 20)
        {
            if (hitCount >= vida)
                Destroy(gameObject);
            if (Random.Range(0, freqTiros) == 2 & Time.time - balaTime >= 1)
                AttackL();
            else if (Random.Range(0, freqTiros) == 4 & Time.time - balaTime >= 1)
                AttackH();
        }
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
        Instantiate(bullet, transform.position + (Vector3.left) + (Vector3.down * 4 / 6), Quaternion.identity);
        balaTime = Time.time;
    }
    public void AttackH()
    {
        //atack
        Instantiate(bullet, transform.position + (Vector3.left) + (Vector3.up * 4 / 6), Quaternion.identity);
        balaTime = Time.time;
    }
}
