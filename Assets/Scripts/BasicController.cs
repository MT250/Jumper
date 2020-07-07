using UnityEngine;

public class BasicController : MonoBehaviour
{
    [SerializeField] private MovementType movementType = MovementType.Translate;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float sideMovementSpeed;
    [Space]
    [SerializeField] private float sprintSpeedMultiplyer;
    [SerializeField] private float jumpForce;

    [Space]
    [Header("Debug")]
    [SerializeField] private bool canJump;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private Rigidbody rbody;

    void Awake() => rbody = GetComponent<Rigidbody>();   
  

    void Update()
    {
        ReadKeyboradInput();
    }

    private void ReadKeyboradInput()
    {
        //Movement
        if (Input.GetAxis("Vertical") != 0)
        {
            var vertical = Input.GetAxis("Vertical");
            if (movementType == MovementType.Translate) transform.Translate(Vector3.forward * vertical * movementSpeed * sprintSpeed * Time.deltaTime);
            else if (movementType == MovementType.AddForce) rbody.AddForce(Vector3.forward * vertical * movementSpeed * sprintSpeed);

        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            var horizontal = Input.GetAxis("Horizontal");
            if (movementType == MovementType.Translate) transform.Translate(Vector3.right * horizontal * sideMovementSpeed * Time.deltaTime);
            else if (movementType == MovementType.AddForce) rbody.AddForce(Vector3.right * horizontal * sideMovementSpeed);
        }

        //Jumping
        if (Input.GetKey(KeyCode.Space) && canJump) 
        {
            canJump = false;
            rbody.AddForce(Vector3.up * jumpForce); 
        }

        //Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprintSpeed = sprintSpeedMultiplyer;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprintSpeed = 1;
        }
    }

    public void AllowJumping()
    {
        if (!canJump) canJump = true;
    }

    public void RestictJumping()
    {
        canJump = false;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!canJump) canJump = !canJump;
    //}


    enum MovementType
    {
        Translate,
        AddForce
    }

}
