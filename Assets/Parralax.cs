using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public Transform alvo;
    public float velocidadeRelativa;
    float posAntX;

    void Start()
    {
        if (velocidadeRelativa == 0)
            velocidadeRelativa = 1;

        posAntX = alvo.position.x;
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void EfeitoParallax()
    {
        transform.Translate((alvo.position.x - posAntX)/ velocidadeRelativa, 0,0);
        posAntX = alvo.position.x;
    }

    void Update()
    {
        EfeitoParallax();
    }
}
