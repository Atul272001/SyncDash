using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 8f;
    [SerializeField] float gravity = -20f;

    float speedInceraseTimer = 5f;

    float verticalVelocity;

    bool jumpedThisFrame = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
        Jump();

        if (speedInceraseTimer > 0)
        {
            speedInceraseTimer -= Time.deltaTime;
        }
        else
        {
            speed += 2f;
            speed = Mathf.Clamp(speed, 5f, maxSpeed);

            speedInceraseTimer = 5f;
        }


        SyncSystem.instance.SendState(
            transform.position,
            jumpedThisFrame
        );

        jumpedThisFrame = false;
    }

    void Movement()
    {
        Vector3 move = Vector3.forward * speed;

        if (characterController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;

        move.y = verticalVelocity;

        characterController.Move(move * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            verticalVelocity = jumpForce;
            jumpedThisFrame = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.gameObject.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactable.OnInteract();
        }
    }
}
