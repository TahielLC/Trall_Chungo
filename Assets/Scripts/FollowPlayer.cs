using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
