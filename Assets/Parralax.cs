using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public Transform alvo;
    public float velocidadeRelativa;

    void Start()
    {
        if (velocidadeRelativa < 1)
            velocidadeRelativa = 1;

        alvo = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
        
    }
}
