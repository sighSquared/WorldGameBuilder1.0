using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 cam_offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + cam_offset;
    }
}
