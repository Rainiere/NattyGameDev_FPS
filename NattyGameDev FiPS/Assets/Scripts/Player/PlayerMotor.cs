using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    private bool IsGrounded;
    public float Speed; //Adjustable speed variable that changes depending on conditions(e.g. Walking, crouching, sprinting)
    [SerializeField] private float WalkSpeed; // Speed when not sprinting or crouching
    private float CrouchSpeed; //Speed when crouching
    private float SprintSpeed; // Speed when sprinting
    private float Gravity = -9.8f;
    [SerializeField] private float JumpHeight = 3f;
    private float DefaultJumpHeight;
    private bool IsCrouching = false;
    private bool LerpCrouch;
    [SerializeField] private float CrouchTimer;
    private bool IsSprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        DefaultJumpHeight = JumpHeight;
        Controller = GetComponent<CharacterController>();
        Speed = WalkSpeed;
        CrouchSpeed = WalkSpeed/2f;
        SprintSpeed = WalkSpeed * 2f;
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Controller.isGrounded;
    }

    //recieve the inputs from InputManager.cs and apply them to Character Controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 MoveDirection = Vector3.zero;
        MoveDirection.x = input.x;
        MoveDirection.z = input.y;
        Controller.Move(transform.TransformDirection(MoveDirection)* Speed * Time.deltaTime);
        PlayerVelocity.y += Gravity * Time.deltaTime;
        if (IsGrounded && PlayerVelocity.y < 0) { PlayerVelocity.y = -2f; }
        Controller.Move(PlayerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            PlayerVelocity.y = Mathf.Sqrt(JumpHeight * -3.0f * Gravity);
        }
    }
    public void SetJumpHeight(float modifier, bool BuffOn)
    {

        JumpHeight += modifier;
        if (BuffOn == false) { if (IsSprinting) { JumpHeight = DefaultJumpHeight * 1.5f; } else { JumpHeight = DefaultJumpHeight; } }
    }

    public void Crouch()
    {
        IsCrouching = !IsCrouching;
        if (IsCrouching)
        {
            transform.localScale += new Vector3(0, -0.5f, 0);
            Controller.height *= 0.5f;
            Speed = CrouchSpeed;

        }
        if(!IsCrouching)
        {
            transform.localScale += new Vector3(0, 0.5f, 0);
            Controller.height *= 2f;
            Speed = WalkSpeed;
        }
    }

    public void Sprint()
    {
        IsSprinting = !IsSprinting;
        if (IsSprinting)
        {
            Speed = SprintSpeed;
            JumpHeight = JumpHeight * 1.5f;
        }
        if (!IsSprinting)
        {
            Speed = WalkSpeed;
            JumpHeight = JumpHeight / 1.5f;
        }
    }
}
