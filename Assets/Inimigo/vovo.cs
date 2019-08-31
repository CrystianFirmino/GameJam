using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vovo: MonoBehaviour
{
    public int vida = 50;
    public int freqTiros = 100;
    public GameObject bolsa;
    public GameObject chapeu;
    public GameObject player;
    
    int hitCount = 0;

    float balaTime;

    void Update()
    {
        if (player == null)
        {
            return;
        }

        if (transform.position.x - player.transform.position.x < 20)
        {
            if (hitCount >= vida)
                Morrer();

            if (Random.Range(0, freqTiros) == 2 & Time.time - balaTime >= 1)
                AttackL();

            else if (Random.Range(0, freqTiros) == 4 & Time.time - balaTime >= 1)
                AttackH();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala" && transform.position.x - player.transform.position.x < 20)
        {
            hitCount += 1;
        }
    }

    public void AttackL()
    {
        //atack
        Instantiate(bolsa, transform.position + (Vector3.left) + (Vector3.down * 4 / 3), Quaternion.identity);
        balaTime = Time.time;
    }

    public void AttackH()
    {
        //atack
        Instantiate(chapeu, transform.position + (Vector3.left) + (Vector3.up * 1 / 7), Quaternion.identity);
        balaTime = Time.time;
    }

    private void Morrer()
    {
        Destroy(gameObject);
    }
}
