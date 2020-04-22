using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; //Movement smoothing for the charactor
    [SerializeField] private bool m_AirControl = false; //Allow control for character in the air
    [SerializeField] private bool m_StickToSlopes = true; //Sitck to slopes to allow for easier controls
    [SerializeField] private LayerMask m_WhatIsGround; //What layer is ground                        
    [SerializeField] private Transform m_GroundCheck = null; //Ground check gameobject
    [SerializeField] private Transform m_FrontCheck = null;  //Front check gameobject
    [SerializeField] private float m_GroundedRadius = .05f;//Radius for ground check               
    [SerializeField] private float m_FrontCheckRadius = .05f;//Radius for front check  
    [SerializeField] private float m_GroundRayLength = .5f;//Radius for ground ray length check  


    private float m_OriginalGravityScale;
    
    [Header("Events")]
    public UnityEvent OnLandEvent; //Unity event for when the character lands
    public GameObject leftBullet, rightBullet; //GameObjects for the left and right bullets
    public bool IsGrounded; //Is the character grounded
    public bool IsFrontBlocked { get; private set; } //Is the front of the character blocked
    public bool IsFacingRight { get; private set; } = true; //Is the character facing right
    public Rigidbody2D Rigidbody { get; private set; } //Character rigidbody
    public Animator Anim { get; private set; } //Character animatior
    public float Speed; //The speed float
    [Header("Abilites")]
    public bool doubleJump = true; //Double jump bool
    public bool airTesting; //Air testing for if the player is in the air and has double jumped
    public bool glide = false; //s
    public bool HasParameter(string paramName, Animator animator)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName)
                return true;
        }
        return false;
    }


    private void Awake()
    {
        //Set speed to 0
        Speed = 0;
        //Get rigidbody component and set into variable
        Rigidbody = GetComponent<Rigidbody2D>();
        //Get animator component and set into variable
        Anim = GetComponent<Animator>();
        //Get rigidbody gravity scale and set into a variable 
        m_OriginalGravityScale = Rigidbody.gravityScale;
        //If OnLandEvent is null, Set it to equal a new unity event
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

    }

    private void FixedUpdate()
    {
        if (glide == true)
        {
            if (Rigidbody.velocity.y <= 0)
            {
                Rigidbody.gravityScale = 1f;
            }
            Anim.SetBool("Glide", true);
        }
        else
        {
            Anim.SetBool("Glide", false);
            Rigidbody.gravityScale = 5f;
        }
        //Start the defualt animations
        AnimateDefault();
        //Change the bool wasGrounded to the state of IsGrounded
        bool wasGrounded = IsGrounded;
        //Change IsGounded to false
        IsGrounded = false;
        //Check for if the front is blocked to false
        IsFrontBlocked = false;
        //Add all the colliders within a circle area of ground check position to colliders
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, m_GroundedRadius, m_WhatIsGround);
        //run check for every collider
        for (int i = 0; i < colliders.Length; i++)
        {
            //if the game object is not the player
            if (colliders[i].gameObject != gameObject)
            {
                //Set IsGrounded to true
                IsGrounded = true;
                Anim.SetBool("Glide", false);
                //If wasGrounded was false 
                if (!wasGrounded)
                    //Invoke OnLandEvent
                    OnLandEvent.Invoke();
            }
        }
        //Add all the colliders within a circle area of front check position to colliders
        colliders = Physics2D.OverlapCircleAll(m_FrontCheck.position, m_FrontCheckRadius, m_WhatIsGround);
        //run check for every collider
        for (int i = 0; i < colliders.Length; i++)
        {
            //if the game object is not the player
            if (colliders[i].gameObject != gameObject)
            {
                //Set IsFrontBlocked to true
                IsFrontBlocked = true;
            }
        }

    }

    //Default set of animations
    private void AnimateDefault()
    {
        //If IsGrounded Exist set animation to the state of IsGrounded
        if (HasParameter("Grounded", Anim))
            Anim.SetBool("Grounded", IsGrounded);
        //If JumpY Exist set animation to the float of Rigidbodys vertical velocity 
    }

    public void Landed()
    {
        if (IsGrounded)
        {
            glide = false;
            airTesting = false;
        }
    }
    
    //When jump is trigged
    public void Jump(float height)
    {
        if (!IsGrounded && doubleJump && !airTesting)
        {
            Rigidbody.AddForce(new Vector2(0.5f, height - Rigidbody.velocity.y), ForceMode2D.Impulse);
            airTesting = true;
            Anim.SetTrigger("Double Jump");
        }
        else
        if (IsGrounded && !airTesting)
        {
            IsGrounded = false;
            Rigidbody.AddForce(new Vector2(0.5f, height + Rigidbody.velocity.y), ForceMode2D.Impulse);
            Anim.SetTrigger("Jump");
        }
        else
        {

        }
        

    }
    public void Magic()
    {   
        if (IsFacingRight == true)
        {
            Instantiate(rightBullet, m_FrontCheck.transform.position, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Instantiate(leftBullet, m_FrontCheck.transform.position, new Quaternion(0,0,0,0));
        }
    }
    

    public void Move(float offsetX)
    {
        //If Animator has parameter IsRuunning
        //if (HasParameter("IsRunning", Anim))
            //Set Bool for IsRUnning 
            //Anim.SetBool("IsRunning", offsetX != 0);
        //If IsGrounded is true as well as AirControl
        if (IsGrounded || m_AirControl)
        {
            //If Stick to Slopes is true
            if (m_StickToSlopes)
            {
                //Nre ray the points downward from the player
                Ray groundRay = new Ray(transform.position, Vector3.down);
                //Check what the raycast has hit and set it to a variable
                RaycastHit2D groundHit = Physics2D.Raycast(groundRay.origin, groundRay.direction, m_GroundRayLength, m_WhatIsGround);
                //If the raycast has hit something
                if (groundHit.collider != null)
                {
                    //New Vector3 to find the slopes direction
                    Vector3 slopeDirection = Vector3.Cross(Vector3.up, Vector3.Cross(Vector3.up, groundHit.normal));
                    //set new variable slope thats the product of two vectors 
                    float slope = Vector3.Dot(Vector3.right * offsetX, slopeDirection);
                    //Calculate the slope added  to the of
                    offsetX += offsetX * slope;
                    //Get the float angle from the vector
                    float angle = Vector2.Angle(Vector3.up, groundHit.normal);
                    //If the angle is greater than 0
                    if (angle > 0)
                    {
                        //Set Rigidbodys gravity to 0
                        Rigidbody.gravityScale = 0;
                        //Change Rigidbody velocity to new Vector2 using Velocity x
                        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, 0f);
                    }
                }
            }
            //
            Vector3 targetVelocity = new Vector2(offsetX*(Speed + 1), Rigidbody.velocity.y);
            //New Vector3 velocity
            Vector3 velocity = Vector3.zero;
            //Changes the rigidbody velocity 
            Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
        }
    }
}