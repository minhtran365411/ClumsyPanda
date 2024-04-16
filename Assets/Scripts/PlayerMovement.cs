using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{   
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float jumpHorizontalSpeed;

    [SerializeField]
    private float jumpButtonGracePeriod;

    [SerializeField]
    private Transform cameraTransform;

    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;

    //attack
    public int damageAmount;
    Transform enemyTransform;
    GameObject enemy;
    public GameObject appleObj;
    public Transform applePoint;

    //collect key
    public int attribute = 0;
    static public int HAVEKEY = 1;



    // Start is called before the first frame update
    void Start()
    {   
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void OnTriggerEnter(Collider Col) {
        
        if (Col.tag == "Key") { 
            attribute |= HAVEKEY;
            Debug.Log(attribute);
            Destroy(Col.gameObject);
            //play sound effects
            AudioManager.instance.Play("Collected");
        }
        
        
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
    //moving code
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        
        movementDirection.Normalize();
        
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;

        ySpeed += Physics.gravity.y * Time.deltaTime;

        // float magnitude = Mathf.Clamp01(movementDirection.magnitude);

        // if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        // {
        //     magnitude /= 2;
        // }

        // animator.SetFloat("magnitude", magnitude, 0.05f, Time.deltaTime);

        // movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        // movementDirection.Normalize();

        // ySpeed += Physics.gravity.y * Time.deltaTime;



        if (characterController.isGrounded) {
            lastGroundedTime = Time.time;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);
            animator.SetBool("isAttacking", false);
        }

        if (Input.GetButtonDown("Jump")) {
            jumpButtonPressedTime = Time.time;
        }

        //has Grounded recently?
        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod) {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);

            //jump btn has been pressed recently?
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod) {
                 ySpeed = jumpSpeed;
                 animator.SetBool("isJumping", true);
                 isJumping = true;
                 jumpButtonPressedTime = null;
                 lastGroundedTime = null;
            }

        } else {
            characterController.stepOffset = 0;
            animator.SetBool("isGrounded", false);
            isGrounded = false;

            //fall off cliffs/hills
            if ((isJumping && ySpeed < 0) || ySpeed < -2) {
                animator.SetBool("isFalling", true);
            }
        }

            Vector3 velocity = movementDirection * magnitude;
            velocity.y = ySpeed;

            characterController.Move(velocity * Time.deltaTime);

        if (isGrounded) {
            Vector3 velocityMove = animator.deltaPosition;
            velocityMove.y = ySpeed * Time.deltaTime;
            characterController.Move(velocityMove);
        }

    //rotating code
        if (movementDirection != Vector3.zero) {
            animator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        } else {
            animator.SetBool("isMoving", false);
        }

        if (isGrounded == false) {
            Vector3 velocityGrounded = movementDirection * magnitude * jumpHorizontalSpeed;
            velocityGrounded.y = ySpeed;

             characterController.Move(velocityGrounded * Time.deltaTime);
        }


        //melle attack

        if (Input.GetKeyDown("c")) {
            //if (enemy) {
            //float distance = Vector3.Distance(enemyTransform.position, animator.transform.position);
                 //if(distance < 4f) {
                
                animator.SetBool("isAttacking", true);
                
                //enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
                //} 
                

            //}
        }

        
        //aiming
        if (Input.GetMouseButton(1))
        {
            //Debug.Log("The right mouse button is being held down.");
            if (characterController.isGrounded && horizontalInput <= 0 && verticalInput <= 0) {
                //Play Aim Anim
                animator.SetBool("isAiming", true);
            } else if (horizontalInput > 0 || verticalInput > 0) {
                //animator.SetBool("isAiming", false);
                animator.SetBool("isAimWalk", true);
            }
           
        } else {
            //Stop Aim Anim
            animator.SetBool("isAiming", false);
            animator.SetBool("isAimWalk", false);
        }

 
        //throwing attack //Left mouse
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isThrowing", true);
     
        } else {
            animator.SetBool("isThrowing", false);
        }
        
    
    }

    public void ThrowApple() {
        //Debug.Log("Throw");
        GameObject apple = Instantiate(appleObj, applePoint.position, transform.rotation);
        //adding force to throw forward
        apple.GetComponent<Rigidbody>().AddForce(transform.forward * 30f, ForceMode.Impulse);
        
    }


    // private void OnApplicationFocus(bool focus) {
    //     if(focus) {
    //         Cursor.lockState = CursorLockMode.Locked;
    //     } else {
    //         Cursor.lockState = CursorLockMode.None;
    //     }
    // }  

   

    

}
