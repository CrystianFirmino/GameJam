using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Inimigo : MonoBehaviour
{
    public int vel_bala = 12;

    float startTime;
    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        transform.position += Vector3.left * vel_bala * Time.deltaTime;
        if (Time.time - startTime >= 10)
            Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
