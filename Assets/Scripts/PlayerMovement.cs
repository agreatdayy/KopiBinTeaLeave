using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myCapsuleCollider;
    float gravityScaleInit;
    

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleInit = myRigidBody.gravityScale;
    }

    void Update()
    {
        Run();
        FlipSPrite();
        ClimbLadder();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value) {
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return ;}

        if (value.isPressed) {
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run() {
        Vector2 playerVelo = new Vector2(moveInput.x * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelo;

        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", hasHorizontalSpeed);
    }

    void FlipSPrite() {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    void ClimbLadder() {
        if (!myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) { 
            myRigidBody.gravityScale = gravityScaleInit;
            myAnimator.SetBool("isClimbing", false);
            return ;
        }
        
        myRigidBody.gravityScale = 0f;
        Vector2 climbVelo = new Vector2(myRigidBody.velocity.x, moveInput.y * climbSpeed);
        myRigidBody.velocity = climbVelo;

        bool hasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", hasVerticalSpeed);
    }
}
