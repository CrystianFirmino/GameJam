﻿using UnityEngine;

public class Player : MonoBehaviour
{
    public int vida = 5;
    float balaTime;
    private Rigidbody2D heroi;
    //private BoxCollider2D col;
    public int vel = 3;
    public bool mov = false; //<-------------- Movimento
    public bool agc = false; //<-------------- Agachado
    public bool pol = false; //<-------------- Pulando
    public GameObject bullet;
    public int force = 320;

    int hitCount = 0;

    Vector3 scale;
    bool isGround = false;

    private Animator anin; //<--------------
    private void Start()
    {
        heroi = GetComponent<Rigidbody2D>();
        //col = GetComponent<BoxCollider2D>();
        scale = transform.localScale;
        anin = GetComponent<Animator>();//<--------------
    }
    
    public void Update()
    {
        anin.SetBool("mov", mov); //<--------------
        anin.SetBool("agc", agc); //<--------------
        anin.SetBool("pul", pol); //<--------------
        agc = false; //<--------------
        mov = false; //<--------------
        pol = false; //<--------------

        if (Input.GetKey(KeyCode.DownArrow))
            Agachar();
        else
        {
            transform.localScale = scale;
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
                Jump();
            if(!isGround)
                pol = true;
            if (Input.GetKeyDown(KeyCode.Space) & Time.time - balaTime >= 1)
                Attack();
            if (Input.GetKey(KeyCode.LeftArrow))
                MoveLeft();
            if (Input.GetKey(KeyCode.RightArrow))
                MoveRight();
        }
        if (hitCount >= vida)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Balainimiga")
        {
            hitCount += 1;
        }
        if (collision.gameObject.tag == "nimigo")
        {
            hitCount += 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    public void MoveRight()
    {
        //ir para bolsonaro
        mov = true; //<--------------
        transform.position += Vector3.right * vel * Time.deltaTime;
    }
    public void MoveLeft()
    {
        //ir para haddad
        mov = true; //<--------------
        transform.position += Vector3.left* vel * Time.deltaTime;
    }
    public void Jump()
    {
        //eu quero ir pra frente
        
        heroi.AddForce(new Vector3(0,1,0) * force);
    }
    public void Agachar()
    {
        //eu quero ir pra frente
        agc = true; //<--------------

        //Falta diminuir a Box Collider

        //transform.localScale = scale /2;

    }
    public void Attack()
    {
        //atack
        Instantiate(bullet, transform.position + (Vector3.right), Quaternion.identity);
        balaTime = Time.time;
    }
}
