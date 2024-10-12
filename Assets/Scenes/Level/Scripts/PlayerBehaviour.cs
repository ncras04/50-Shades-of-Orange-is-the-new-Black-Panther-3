using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerBeha : MonoBehaviour
{
    [SerializeField] float jumpForce = 100;
    [SerializeField] float moveForce = 5;
    [SerializeField] float velocity = 1;
    [SerializeField] Transform rayCastOrigin;

    Rigidbody playerMove;


    public void OnCollisionEnter(Collision col)
    {
        bool isColliding = true;
        //isGrounded = true;
    }
    public void OnCollisionExit(Collision col)
    {
        bool isColliding = false;
        //isGrounded = false;
    }

    bool isGrounded;
    Vector3 vel = new();



    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jumpe
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerMove.AddForce(transform.up * jumpForce);
            isGrounded = false;
        }

        // Directional Movement
        if (Input.GetKey(KeyCode.W))
        {
            playerMove.AddForce(-moveForce, vel.y, vel.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerMove.AddForce(moveForce, vel.y, vel.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerMove.AddForce(vel.x, vel.y, -moveForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerMove.AddForce(vel.x, vel.y, moveForce);
        }
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(rayCastOrigin.position, Vector3.down, 0.01f)) //0.01f hat sich als gut erwiesen
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
