using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public List<GameObject> lifes;

    public void TakeDamage(int i)
    {
        if(i < lifes.Count) lifes[i].SetActive(false);
    }
}
