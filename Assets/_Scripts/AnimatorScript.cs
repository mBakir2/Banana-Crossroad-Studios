using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 14th Feb 2020
 */
public class AnimatorScript : MonoBehaviour
{

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    public Vector3 velocity;
    public bool isGrounded;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("Stopped", false);
        }

        if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("Stopped", true);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            animator.SetBool("isGrounded", true);
        }

        if (Input.GetButton("Jump") && isGrounded)
        {
            animator.SetBool("isGrounded", false);
        }

        if (velocity.y == 0 && velocity.x == 0 && velocity.z == 0)
        {
            animator.SetBool("Stopped", true);
        }
        else
        {
            animator.SetBool("Stopped", false);
        }

        //animator.SetFloat("Speed", velocity.magnitude);

        //Debug.Log("Velocity Magnitude: " + velocity.magnitude);
    }
}
