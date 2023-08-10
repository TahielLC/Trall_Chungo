using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Enemy : RecyclableObject
{
    public int maxHealt = 100;
    int currentHealt;
    public Vector3 pos;

    internal override void Init()
    {
        Invoke(nameof(Recycle), 5);
    }

    internal override void Release()
    {
        Debug.Log("Reciclado");
    }
    private void Start()
    {
        pos = transform.position;
        pos += new Vector3(2, 2, 0);
        currentHealt = maxHealt;
        // Debug.Log(pos);

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
