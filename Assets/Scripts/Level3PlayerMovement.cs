using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Level3PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleInit;

    void Start()
    {
        // Sets components of player character
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleInit = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Moves player characters
        Run();
        FlipSPrite();
    }

    // Moves characters horizontally according to player input
    void Run() {
        Vector2 playerVelo = new Vector2(moveInput.x * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelo;

        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", hasHorizontalSpeed);
    }

    // Flips characters according to direction they are moving
    void FlipSPrite() {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    // Sets character movement speed based on player input
    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }
    
    // Sets vertical movement speed of characters based on player input
    void OnJump(InputValue value) {
        // Checks that character is on ground before jumping. Prevents double jumps.
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Interactables"))) { return ;}

        if (value.isPressed) {
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
}
