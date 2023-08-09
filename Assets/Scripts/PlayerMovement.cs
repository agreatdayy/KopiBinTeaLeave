using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 rip = new Vector2(10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] float respawnDelay = 2f;

    [SerializeField] AudioSource jumpSFX;
    [SerializeField] AudioSource footstepSFX;
    [SerializeField] AudioSource dieSFX;
    [SerializeField] AudioSource shootSFX;
    [SerializeField] AudioSource pickUpItemSFX;
    


    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleInit;
    bool isAlive = true;
    bool hasLabKey = false;
    private Vector3 respawnPoint;
    

    void Start()
    {
        // Sets character's components
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleInit = myRigidBody.gravityScale;
        respawnPoint = transform.position;
    }

    void Update()
    {
        // Ensures characters can oly move when alive
        if (!isAlive) { return ; }
            
        // Moves characters based on player input
        Run();
        FlipSPrite();
        ClimbLadder();
        Die();
    }

    // Sets character movement speed based on player input
    void OnMove(InputValue value) {
        if (!isAlive) { return ; }
        
        footstepSFX.Play();
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    // Sets character vertical movement speed based on player input
    void OnJump(InputValue value) {
        if (!isAlive) { return ; }
        
        // Checks that character is on ground before jumping. Prevents double jumps.
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground", "Interactables"))) { return ;}

        if (value.isPressed) {
            Debug.Log("Jump!!");
            jumpSFX.Play();
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    // Fires bullets if player is alive.
    void OnFire(InputValue value) {
        if (isAlive) {
            Debug.Log("Pew!!");
            shootSFX.Play();
            Instantiate(bullet, gun.position, transform.rotation);
        }
    }

    // Moves player horizontally
    void Run() {
        Vector2 playerVelo = new Vector2(moveInput.x * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelo;

        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", hasHorizontalSpeed);
    }

    // Flips player sprite based on direction of horizontal movement
    void FlipSPrite() {
        bool hasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (hasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    // Allows vertical movement of chracters when touching a ladder
    void ClimbLadder() {
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) { 
            myRigidBody.gravityScale = gravityScaleInit;
            myAnimator.SetBool("isClimbing", false);
            return ;
        }
        
        Debug.Log("Start climbing :(");
        myRigidBody.gravityScale = 0f;
        Vector2 climbVelo = new Vector2(myRigidBody.velocity.x, moveInput.y * climbSpeed);
        myRigidBody.velocity = climbVelo;

        bool hasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", hasVerticalSpeed);
    }

    // Kills players when they touch a hazard or enemy 
    void Die() {
        bool isBodyTouching = myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards"))
                                || myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards"));
        if (isBodyTouching) {
            isAlive = false;
            myRigidBody.velocity = new Vector2(0, 0);
            Debug.Log("RIP!");
            dieSFX.Play();
            myAnimator.SetTrigger("Dying");
            StartCoroutine(Respawn());
            isAlive = true;
        }
    }

    // Respawns player after death
    IEnumerator Respawn() {
        Debug.Log("Death can't stop me");
        yield return new WaitForSecondsRealtime(respawnDelay);
        transform.position = respawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Sets respawn point of player to current position when they enter a respawn checkpoint
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Respawn"))) {
            Debug.Log("Respawn Point reached!");
            respawnPoint = transform.position;
        }

        // for level 2-1
        // Allows player to pick up key and use key to unlock lab door
        if (other.tag == "LabKey") {
            Debug.Log("Lab Key picked up");
            pickUpItemSFX.Play();
            hasLabKey = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "LabLock" && hasLabKey) {
            Debug.Log("Lab door is unlocked");
            hasLabKey = false;
            Destroy(other.gameObject);
        } else if (other.tag == "LabLock" && !hasLabKey) {
            Debug.Log("Lab door is locked");
        }
    }
}
