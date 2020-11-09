using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator animator;
    private Vector2 ScreenBoundaries;

    private float SpriteWidth, SpriteHeight;

    internal bool IsInputLocked;
    private bool IsRunning;
    private bool IsJumping;
    private bool IsGrounded;
    internal bool IsPlayerFacingRight = true;

    public int Health;
    public float Speed;
    public float JumpForce;
    public float HurtForceX;
    public float HurtForceY;
    public float RayCastDistance;
    public LayerMask GroundLayer;
    public ParticleSystem Particle;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SpriteWidth = GetComponent<SpriteRenderer>().size.x;
        SpriteHeight = GetComponent<SpriteRenderer>().size.y;


        ScreenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (!IsInputLocked)
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
                IsJumping = true;

            if (Input.GetKeyUp(KeyCode.Z))
                GetHurt();
        }
    }

    void FixedUpdate()
    {
        if (!IsInputLocked)
        {
            Move();
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, RayCastDistance, GroundLayer);

        if (hit.collider != null)
        {
            IsGrounded = true;
            animator.SetBool("IsGrounded", true);
        }
        else
        {
            IsGrounded = false;
            IsJumping = false;
            animator.SetBool("IsGrounded", false);
        }

        if (IsJumping)
        {
            rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }

    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, ScreenBoundaries.x * -1 + SpriteWidth, ScreenBoundaries.x - SpriteWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, ScreenBoundaries.y * -1 + SpriteHeight, ScreenBoundaries.y - SpriteHeight);
        transform.position = viewPos;
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        rigid.velocity = movement.normalized * Speed;

        Flip();

        if (IsGrounded)
        {
            if (Input.GetAxis("Horizontal") == 0f)
            {
                IsRunning = false;
                animator.SetBool("IsRunning", IsRunning);
            }
            else
            {
                IsRunning = true;
                animator.SetBool("IsRunning", IsRunning);
            }
        }
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            IsPlayerFacingRight = true;
        }


        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            IsPlayerFacingRight = false;
        }
    }

    void GetHurt()
    {
        Health--;

        if (Health >= 1)
        {
            animator.SetTrigger("GetHurt");

            if (IsPlayerFacingRight)
            {
                rigid.AddForce(new Vector2(-HurtForceX, HurtForceY));
            }
            else
            {
                rigid.AddForce(new Vector2(HurtForceX, HurtForceY));
            }
        }
        else
        {
            animator.SetTrigger("Dead");
        }
    }

    void SetInputLocked(string message)
    {
        if (message.ToLower().Equals("true"))
            IsInputLocked = true;
        else
            IsInputLocked = false;
    }

    void Dust()
    {
        Particle.Play();
    }
}
