using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Arquiinimigo : MonoBehaviour
{
    public int vida = 3;

    int count = 0;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
            Destroy(gameObject);
        if (Random.Range(0, 10) == 2)
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
        //balaTime = Time.time;
    }
}