using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Animator animator;
    SpriteRenderer sp;

    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerAnimatorManager AnimatorPlayer;
    [SerializeField] Transform attackPonit;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float attackRagne = 0.5f;
    [SerializeField] float speed = 1f;

    [SerializeField] float impulso = 0.1f;





    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    public void move()
    {

        Vector3 move = Vector3.zero;


        if (Input.GetKey("w"))
        {
            move += Vector3.up;
            //transform.Translate(Vector3.up * Time.deltaTime * speed);

        }
        if (Input.GetKey("s"))
        {
            move += Vector3.down;
            //transform.Translate(Vector3.down * Time.deltaTime * speed);

        }
        if (Input.GetKey("d"))
        {
            move += Vector3.right;
            sp.flipX = false;

        }

        if (Input.GetKey("a"))
        {
            move += Vector3.left;
            //transform.Translate(Vector3.left * Time.deltaTime * speed);
            sp.flipX = true;
        }
        move = move.normalized;
        transform.Translate(move * Time.deltaTime * speed);




        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            AnimatorPlayer.ChangeAnimationState(AnimatorPlayer.PLAYER_RUN);
        }



        if (Input.GetKey("space") && CheckGround.isGrounded)
        {

            rb.AddForce((move + Vector3.forward) * impulso, ForceMode.Impulse);
            AnimatorPlayer.ChangeAnimationState(AnimatorPlayer.PLAYER_JUMP);
            Debug.Log(CheckGround.isGrounded);

        }


    }
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            AnimatorPlayer.ChangeAnimationState(AnimatorPlayer.PLAYER_ATTACK1);
            Collider[] hitenemies = Physics.OverlapSphere(attackPonit.position, attackRagne, enemyLayer);
            foreach (Collider enemy in hitenemies)
            {
                Debug.Log("le pego a", enemy);
            }

        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackPonit == null)
            return;

        Gizmos.DrawWireSphere(attackPonit.position, attackRagne);
    }


    void Update()
    {
        if (!(Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("k")) && !(Input.GetKey("space")))
        {
            AnimatorPlayer.ChangeAnimationState(AnimatorPlayer.PLAYER_IDLE);
        }
        Attack();
        move();


    }
}
