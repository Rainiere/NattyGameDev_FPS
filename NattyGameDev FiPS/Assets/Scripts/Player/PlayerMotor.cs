using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 PlayerVelocity;
    private bool IsGrounded;
    public float Speed = 5f;
    private float Gravity = -9.8f;
    public float JumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
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
}
