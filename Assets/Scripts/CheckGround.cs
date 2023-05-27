using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;


    private void OnTriggerEnter(Collider collision)
    {
        isGrounded = true;
    }
    // private void OnTriggerEnter(Collider collision)
    // {
    //     isGrounded = true;
    // }
    private void OnTriggerExit(Collider collision)
    {
        isGrounded = false;
    }
    // private void OnTriggerExit(Collider collision)
    // {
    //     isGrounded = false;
    // }
    void Start()
    {
        Debug.Log(isGrounded);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isGrounded);
    }
}
