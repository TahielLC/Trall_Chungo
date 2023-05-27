using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    public Animator animator;
    private string currentState;

    [SerializeField]
    public string PLAYER_IDLE = "Player_idle";
    public string PLAYER_RUN = "Player_Run";
    public string PLAYER_WALK = "Player_walk";
    public string PLAYER_ATTACK = "Player_attack";
    public string PLAYER_JUMP = "Player_jump";

    public string PLAYER_ATTACK1 = "Player_attack1";
    public string PLAYER_AIR_ATTACK = "Player_air_attack";

    void Start()
    {

    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        animator.Play(newState);
        //animator.StopPlayback();

        //Debug.Log("aninacion active");
    }





}
