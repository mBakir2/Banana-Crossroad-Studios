using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 14th Feb 2020
 */

public class PlayerBehaviour : MonoBehaviour
{

    public CharacterController controller;

    public float maxSpeed = 10.0f;
    public float gravity = -30f;
    public float jumpHeight = 3.0f;
    private InputManager inputManager;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        if (inputManager.GetButtonDown("Jump") && isGrounded)
        {
            move = transform.right * 1f; //+ transform.forward * z;
            controller.Move(move * maxSpeed * Time.deltaTime);
        }
        /*
        if (Input.GetKeyDown(GameData.sKey))
        {
            Vector3 move = transform.right * -1f;  //+ transform.forward * z;
            controller.Move(move * maxSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(GameData.aKey))
        {
            Vector3 move = transform.forward * 1f;  //+ transform.right * z;
            controller.Move(move * maxSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(GameData.dKey))
        {
            Vector3 move = transform.forward * -1f;  //+ transform.forward * z;
            controller.Move(move * maxSpeed * Time.deltaTime);
        }
        */

        if (Input.GetKeyDown(GameData.jumpKey) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
