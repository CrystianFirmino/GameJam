using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int vel_bala = 8;

    float startTime;
    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        transform.position += Vector3.right * vel_bala * Time.deltaTime;
        if (Time.time - startTime >=10)
            Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nimigo")
            Destroy(gameObject);
    }
}
