using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public int vel_bala = 5;
    float startTime;
    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        transform.position += Vector3.right * vel_bala * Time.deltaTime;
        if (Time.time - startTime >=10)
        {
            Destroy(gameObject);
        }
    }
}
