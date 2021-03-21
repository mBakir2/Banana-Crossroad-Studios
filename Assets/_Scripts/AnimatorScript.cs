using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 16th Feb 2020
 */
public class AnimatorScript : MonoBehaviour
{

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Player Animations")]
    public Joystick joystick;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // animations for the WebGl
        //if (Input.GetKey(GameData.rightKey) && isGrounded)
        //{
        //    animator.SetBool("Stopped", false);
        //}
        //else if (Input.GetKey(GameData.leftKey) && isGrounded)
        //{
        //    animator.SetBool("Stopped", false);
        //}
        //else if (Input.GetKey(GameData.forwardKey) && isGrounded)
        //{
        //    animator.SetBool("Stopped", false);
        //}
        //else if (Input.GetKey(GameData.backKey) && isGrounded)
        //{
        //    animator.SetBool("Stopped", false);
        //}
        //else
        //{
        //    animator.SetBool("Stopped", true);
        //}

        animator.SetInteger("gunActive", GameData.gunActive);

        if ((joystick.Horizontal != 0 || joystick.Vertical != 0) && isGrounded)
        {
            animator.SetBool("Stopped", false);
        } 
        else
        {
            animator.SetBool("Stopped", true);
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        //animator.SetFloat("Speed", velocity.magnitude);

        //Debug.Log("Velocity Magnitude: " + velocity.magnitude);
    }
}
