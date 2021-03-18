using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 8th Mar 2020
 */
public class PlayerBehaviour : MonoBehaviour
{

    public CharacterController controller;

    [Header("Movement")]
    public float maxSpeed = 10.0f;
    public float gravity = -30f;
    public float jumpHeight = 3.0f;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public Vector3 velocity;
    public bool isGrounded;

    [Header("Player Abilities")]
    [Range(0, 100)]
    public int health = 100;

    [Header("Player Health Bar")]
    public HealthBarScreenSpaceController playerHealthBar;

    [Header("Player Sounds")]
    public AudioSource attackSound;

    [Header("Player Controls")]
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        GameData.playerHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        //Vector3 move;

        //controller.Move(move * maxSpeed * Time.deltaTime);

        // key mapping for webGL
        // gets the respective key from the game data to move the player in specific direction
        //if (Input.GetKey(GameData.rightKey))
        //{
        //    move = transform.TransformDirection(Vector3.right);
        //    controller.Move(move * maxSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(GameData.leftKey))
        //{
        //    move = transform.TransformDirection(Vector3.left);
        //    controller.Move(move * maxSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(GameData.forwardKey))
        //{
        //    move = transform.TransformDirection(Vector3.forward);
        //    controller.Move(move * maxSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(GameData.backKey))
        //{
        //    move = transform.TransformDirection(Vector3.back);
        //    controller.Move(move * maxSpeed * Time.deltaTime);
        //}

        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * maxSpeed * Time.deltaTime);

        // getting the user selected jump key to increase the y coordinate of the player object
        //if (Input.GetKey(GameData.jumpKey) && isGrounded)
        //{
        //    Jump()
        //}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.Alpha1) && GameData.hasRifle)
        {
            GameData.gunActive = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2) && GameData.hasPistol)
        {
            GameData.gunActive = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (GameData.aidKits != 0)
            {
                GameData.aidKits--;
                GameData.playerHealth += 50;
            }
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        GameData.playerHealth = health;
        playerHealthBar.TakeDamage(damage);
        attackSound.Play();
        if (GameData.playerHealth < 0)
        {
            SceneManager.LoadScene(2);
            //Cursor.lockState = CursorLockMode.None;
        }
    }

    // increases the players y coordinates to make him jump
    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }


}
