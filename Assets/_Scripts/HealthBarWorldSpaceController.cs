using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarWorldSpaceController : MonoBehaviour
{
    public Transform playerCam;

    private void Start()
    {
        playerCam = GameObject.Find("Main Camera").transform;
    }

    void FixedUpdate()
    {
        transform.LookAt(playerCam.position + transform.forward);
    }
}
