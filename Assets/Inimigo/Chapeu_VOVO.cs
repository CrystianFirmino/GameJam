using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapeu_VOVO : MonoBehaviour
{
    public int vel_bala = 12;

    float startTime;
    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (Time.time - startTime < 2.5f)
            transform.position += Vector3.left * vel_bala * Time.deltaTime;
        else 
        {
            transform.position += Vector3.right * vel_bala * Time.deltaTime;
            if (Time.time - startTime >= 5)
                Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
