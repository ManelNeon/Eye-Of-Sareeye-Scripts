using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Animator animator;

    [Header("PlayerMovementSpeed")]

    [SerializeField] float moveSpeed = 2;

    float myGravity = -10f;

    Vector3 inputVector;
    Vector3 movementVector;

    CharacterController mycc;

    [Header("PlayerRotationReset")]

    [SerializeField] float rotationSpeed;
    Quaternion newResetAngle;
    [SerializeField] Camera cam;

    [SerializeField] Transform Screminem;

    Transform og;

    void Start()
    {
        og = Screminem;
        mycc = GetComponent<CharacterController>();
        animator.SetBool(("isDaFast"), true);
    }

    void Update()
    {
        if (Screminem != og)
        {
            Screminem = og;
        }

        if (mycc.enabled == true && !animator.GetCurrentAnimatorStateInfo(0).IsName("Spell"))
        {
            GetInput();
            MovePlayer();
            if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
            {
                Rotation();
            }
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool(("isWalking"), true);
        }
        else
        {
            animator.SetBool(("isWalking"), false);
        }
    }
    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);
        inputVector = Vector3.Lerp(inputVector, Vector3.zero, Time.deltaTime);
        movementVector = (inputVector * moveSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        mycc.Move(movementVector * Time.deltaTime);
    }

    public void Rotation()
    {
        newResetAngle = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, newResetAngle, rotationSpeed * Time.deltaTime).normalized;
    }
}
