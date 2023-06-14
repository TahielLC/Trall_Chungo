using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



public class MyObject : RecyclableObject
{
    internal override void Init()
    {
        Invoke(nameof(Recycle), 5);
    }


    internal override void Release()
    {
        Debug.Log("Reciclado");
    }


}
