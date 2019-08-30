using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Arquiinimigo : MonoBehaviour
{
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

// Update is called once per frame
void Update()
{
    if (count >= 3)
        Destroy(gameObject);
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Bala")
    {
        count += 1;
    }
}
}