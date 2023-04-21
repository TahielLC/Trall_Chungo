using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    public Animator animator;
    private string currentState;

    [SerializeField]
    const string PLAYER_IDLE = "Player_idle";
    const string PLAYER_RUN = "Player_walk";
    const string PLAYER_ATTACK = "Player_attack";
    const string PLAYER_JUMP = "Player_jump";
    const string PLAYER_AIR_ATTACK = "Player_air_attack";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        animator.Play(newState);
    }





}
