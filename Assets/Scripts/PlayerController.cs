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
    // [SerializeField] GameObject player;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float attackRagne = 0.5f;
    [SerializeField] float speed = 1f;

    [SerializeField] float impulso = 0.1f;

    [SerializeField] int attakkDamage = 20;
    [SerializeField] float attackRate = 2f;
    float nextAttack = 0;




    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        // player = GetComponent<GameObject>();
    }
    public void Move()
    {

        Vector3 move = Vector3.zero;
        //Vector3 move2 = Vector3.zero;

        if (Input.GetKey("w"))
        {
            move += Vector3.up;
            //transform.Translate(Vector3.up * Time.deltaTime * speed);


        }
        if (Input.GetKey("s"))
        {
            move += Vector3.down;


        }
        if (Input.GetKey("d"))
        {

            move += Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
            //sp.flipX = false;

        }

        if (Input.GetKey("a"))
        {

            transform.localScale = new Vector3(-1, 1, 1);
            move += Vector3.left;


            // sp.flipX = true;
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
            if ((CheckGround.isGrounded))
            {
                AnimatorPlayer.ChangeAnimationState(AnimatorPlayer.PLAYER_IDLE);
            }


            Debug.Log(CheckGround.isGrounded);

        }



    }
    public void Attack()
    {

        Collider[] hitenemies = Physics.OverlapSphere(attackPonit.position, attackRagne, enemyLayer);
        //Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPonit.position, attackRagne, enemyLayer);
        foreach (Collider enemy in hitenemies)
        {
            enemy.GetComponent<Enemy>().DanioRecibido(attakkDamage);
        }
        AnimatorPlayer.ChangeAnimationState(AnimatorPlayer.PLAYER_ATTACK1);
    }
    void OnDrawGizmosSelected()
    {
        if (attackPonit == null)
            return;

        Gizmos.DrawWireSphere(attackPonit.position, attackRagne);
    }








    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }

        if (!(Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("k")) && !(Input.GetKey("space")))
        {
            AnimatorPlayer.ChangeAnimationState(AnimatorPlayer.PLAYER_IDLE);
        }

        Move();






    }
}
