using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo2 : MonoBehaviour
{
    public int vel = 5;
    public int vida = 20;

    private SpriteRenderer renderer;
    public Gera_inimigos gera;
    int hitCount = 0;
    
    public GameObject player;

    float startTime;
    public float cooldown = 1f;

    private bool dead = false;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        startTime = Time.time;

        //player = GameObject.Find()
    }

    float dir = -1;
    private float timer = 0f;


    void Update()
    {
        if(player == null)
        {
            return;
        }

        if (transform.position.x - player.transform.position.x < 30)
        {
            if (hitCount >= vida)
                Morrer();


            float tempDir = transform.position.x - player.transform.position.x < 0 ? -1 : 1;
            if (tempDir != dir)
            {
                timer = cooldown;
            }
            dir = tempDir;
            if (timer <= 0f)
            {
                transform.position += Vector3.left * vel * Time.deltaTime * dir;
                renderer.flipX = dir == -1;
            }
            timer -= Time.deltaTime;
        }
    }

    //IEnumerator segue()
    //{
    //    while (x = 1)
    //    {
    //        if (transform.position.x - player.transform.position.x > 0)
    //        {
    //            transform.position += Vector3.left * vel * Time.deltaTime;

    //        }
    //        else
    //        {
    //            yield return new WaitForSeconds(3);
    //            transform.position += Vector3.right * vel * Time.deltaTime;
    //            x = 0;
    //        }
    //    }
    //    while (x = 0)
    //    {
    //        if (transform.position.x - player.transform.position.x < 0)
    //        {
    //            transform.position += Vector3.right * vel * Time.deltaTime;

    //        }
    //        else
    //        {
    //            yield return new WaitForSeconds(3);
    //            transform.position += Vector3.left * vel * Time.deltaTime;
    //            x = 1;
    //        }
    //    }
    //}



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
            hitCount += 1;

        if (collision.gameObject.tag == "Player")
        {
            Morrer();
        }
            //Morrer();
            //hitCount += 5;
    }

    private void Morrer()
    {
        if (dead) return;
        dead = true;

        gera.create_Inimigo2();
        Destroy(gameObject);
    }
}
