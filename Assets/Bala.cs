using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int vel_bala = 12;

    float destroyTime = 10;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    void Update()
    {
        transform.position += Vector3.right * vel_bala * Time.deltaTime;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nimigo")
            Destroy(gameObject);
    }
    public void SetDirection(int dir)
    {
        vel_bala = vel_bala * dir;
    }
}
