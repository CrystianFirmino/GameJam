using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo2 : MonoBehaviour
{
    public int vel = 1;

    float startTime;

    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        transform.position += Vector3.left * vel * Time.deltaTime;

        if (Time.time - startTime >= 20) //Mudar para quando sair da tela
            Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
