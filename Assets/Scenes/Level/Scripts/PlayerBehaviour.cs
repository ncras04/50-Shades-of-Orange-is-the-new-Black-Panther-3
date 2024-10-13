using System;
using UnityEditor.PackageManager;
using UnityEngine;


public class PlayerBeha : MonoBehaviour, INotifyProperty<float>
{
    [SerializeField] float jumpForce = 100;
    [SerializeField] float moveForce = 5;
    [SerializeField] float velocity = 1;
    [SerializeField] Transform rayCastOrigin;

    [SerializeField]
    private AudioSource m_jump;
    [SerializeField]
    private AudioSource m_ground;



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

    public bool IsGrounded
    {
        get => isGrounded;
        private set
        {
            if (isGrounded != value)
            {
                isGrounded = value;
                if (isGrounded)
                {
                    m_ground.Play();
                    RaisePropertyChanged();
                }
            }
        }
    }

    private void RaisePropertyChanged()
    {
        RaycastHit hitInfo;
        Physics.Raycast(rayCastOrigin.position, Vector3.down, out hitInfo, 0.01f);

        if (hitInfo.collider is null)
            return;

        PropertyChanged?.Invoke(hitInfo.collider.gameObject.GetComponent<Platform>().Distance);
    }

    Vector3 vel = new();

    public event Action<float> PropertyChanged;



    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jumpe
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerMove.AddForce(transform.up * jumpForce);
            m_jump.Play();
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
        if (Physics.Raycast(rayCastOrigin.position, Vector3.down, 0.01f) && Mathf.Abs(playerMove.velocity.y) < 0.01f) //0.01f hat sich als gut erwiesen
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
}
