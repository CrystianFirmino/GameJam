using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo2 : MonoBehaviour
{
    public int vel = 1;
    public int vida = 3;

    public Gera_inimigos gera;
    int hitCount = 0;
    
    public GameObject player;

    float startTime;

    private void Start()
    {
        startTime = Time.time;
        //player = GameObject.Find()
    }
    void Update()
    {
        if(player == null)
        {
            return;
        }

        if (transform.position.x - player.transform.position.x < 20)
        {
            if (hitCount >= vida)
                Morrer();
                
            transform.position += Vector3.left * vel * Time.deltaTime;
        }

       // if (Time.time - startTime >= 20) //Mudar para quando sair da tela
       //     Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            hitCount += 1;
        }
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }

    private void Morrer()
    {
        gera.qnt_Inimigos2 += 1;
        Destroy(gameObject);
    }
}
