using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealt = 100;
    int currentHealt;

    private void Start()
    {
        currentHealt = maxHealt;
    }


    public void DanioRecibido(int hit)
    {
        currentHealt -= hit;
        if (currentHealt <= 0)
        {
            Die();
        }


    }
    public void Die()
    {
        Debug.Log("C murio");
    }

    void Update()
    {







    }
}
