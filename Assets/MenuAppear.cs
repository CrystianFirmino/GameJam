using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAppear : MonoBehaviour
{

    public GameObject botao1;
    //public GameObject botao2;

    // Start is called before the first frame update
    void Start()
    {
        StartAppearMenu();
        
    }
    IEnumerator appearMenu()
    {
        yield return new WaitForSeconds(10f);

        //aqui coloca a fun;'ao
        botao1.SetActive(true);
       // botao2.SetActive(true);
    }
    
    public void StartAppearMenu()
    {
        StartCoroutine(appearMenu());
    } 
}
