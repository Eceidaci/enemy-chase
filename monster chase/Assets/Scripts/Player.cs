using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject diedtext;
    
    public float moveForce = 10f;
    private float movementX;
    private string WALK_ANIMATION = "walk";

    public float jumpForce = 11f;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        diedtext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
    }
    void FixedUpdate()  //fizikle ilgile uygulamalar buraya(rigitbody gibi)
    {
        PlayerJump();
    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //we get input when we press left or right( 0 , - or +)

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            //we are going right side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;   //character is looking to the right
        }
        else if (movementX < 0)
        {
            //we are going left side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;   //character is looking to the left side
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);

        }
    }
    void PlayerJump()
    {
        if(Input.GetButton("Jump") && isGrounded) 
        {
            isGrounded = false;       //isgrounded false olduðu için sadece bir kere zýplatýr ama baþka zýplayamazsýn
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {    //compara yeg sayesinde karakterlerin colliderlarý etkileþime girince isgrounded true olur                                                               
            isGrounded = true;
            
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {            
            Destroy(gameObject);
            diedtext.SetActive(true);
        }
    }
}
