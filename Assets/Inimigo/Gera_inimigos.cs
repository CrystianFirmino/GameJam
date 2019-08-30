using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gera_inimigos : MonoBehaviour
{
    public GameObject Player;
    public int qnt_Inimigos1 = 1;
    public GameObject inimigo1;
    public int qnt_Inimigos2 = 3;
    public GameObject inimigo2;

    void Start()
    {
        
    }

    void Update()
    {


        while (qnt_Inimigos1 > 0)
            create_Inimigo1();
        while (qnt_Inimigos2 > 0)
            create_Inimigo2();

    }
    private void create_Inimigo1()
    {
        GameObject newEnemy = Instantiate(inimigo1, Player.transform.position +  Vector3.right*20 + Vector3.right * Random.Range(0,20), Quaternion.identity);
        newEnemy.GetComponent<Inimigo1>().player = Player;
        qnt_Inimigos1 = qnt_Inimigos1 - 1;
    }

    private void create_Inimigo2()
    {
        GameObject newEnemy = Instantiate(inimigo2, Player.transform.position +  Vector3.right * 20 + Vector3.right * Random.Range(0, 20), Quaternion.identity);
        newEnemy.GetComponent<Inimigo2>().player = Player;
        newEnemy.GetComponent<Inimigo2>().gera = this;
        qnt_Inimigos2 = qnt_Inimigos2 - 1;
    }
}
