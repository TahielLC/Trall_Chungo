using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Enemy : RecyclableObject
{
    public int maxHealt = 100;
    int currentHealt;
    public Vector3 pos;
    public float slowDistance;
    Vector2 velocity = Vector2.zero;
    private SpriteRenderer spEnemy;

    [SerializeField] Transform player;
    [SerializeField] float followSpeed;



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
        spEnemy = GetComponent<SpriteRenderer>();
        pos = transform.position;
        pos += new Vector3(2, 2, 0);
        currentHealt = maxHealt;
        // Debug.Log(pos);

    }

    private void Steering()
    {
        Vector2 targetPosition = player.position;
        Vector2 playerDistance = (targetPosition - (Vector2)transform.position);
        Vector2 disiredVelocity = playerDistance.normalized * followSpeed;
        Vector2 steering = disiredVelocity - velocity;

        velocity += steering * Time.deltaTime;

        float slowDownFactor = Mathf.Clamp01(playerDistance.magnitude / slowDistance);

        velocity *= slowDownFactor;

        transform.position += (Vector3)velocity * Time.deltaTime;

        spEnemy.flipX = velocity.x < 0;
        if ((velocity.x < 0))
        {

        }
        //attackPonit.eulerAngles = new Vector3(player.position.x, player.position.y, 0);

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
