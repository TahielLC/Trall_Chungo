using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Animator animator;
    [SerializeField] PlayerAnimatorManager AnimatorPlayer;

    [SerializeField] float speed = 1f;
    SpriteRenderer sp;






    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    private void move()
    {



        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            sp.flipX = false;
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            sp.flipX = true;

        }
    }

    void Update()
    {

        move();
    }
}
