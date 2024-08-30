using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    AudioSource playerSource;
    Rigidbody playerRB;

    [SerializeField] float speed_Multiplier;

    [Header("Jump Veriables")]
    [SerializeField] AudioClip jumpSound;
    [SerializeField] float jump_Multiplier;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    bool isGrounded;
    

    float x_axis_input, z_axis_input;

    void Start()
    {
        playerSource = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputForMovement();
        InputForJump();
    }

    void InputForMovement()
    {
        x_axis_input = Input.GetAxisRaw("Horizontal");
        z_axis_input = Input.GetAxisRaw("Vertical");
        //Vector3 move = transform.right * x_axis_input * speed_Multiplier + transform.forward * z_axis_input * speed_Multiplier;
        Move();
    }

    void Move()
    {
        playerRB.AddForce(transform.right * x_axis_input * speed_Multiplier*Time.deltaTime,ForceMode.Force);
        playerRB.AddForce(transform.forward * z_axis_input * speed_Multiplier * Time.deltaTime,ForceMode.Force);
    }

    void InputForJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundCheckRadius,groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerSource.PlayOneShot(jumpSound);
            playerRB.AddForce(transform.up * jump_Multiplier,ForceMode.Impulse);
        }
    }

    

}
