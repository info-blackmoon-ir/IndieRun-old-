using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    private Animator animator;
    public float jumpForce;
    public GameObject player_GFX;

    private Rigidbody2D rb;
    private bool facing_change = true;

    private bool isanimating;
    public float checkRadius;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = player_GFX.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputaxis = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            inputaxis = inputaxis * 3;
        }
        if (!isanimating)
        {
            rb.velocity = new Vector2(inputaxis * speed, rb.velocity.y);
        }
        if (inputaxis != 0 && !isanimating)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {

                animator.SetBool("isrunning", true);
            }
            else
            {
                animator.SetBool("isrunning", false);
                animator.SetBool("iswalking", true);
            }

        }
        else
        {
            animator.SetBool("iswalking", false);
            animator.SetBool("isrunning", false);
        }
        if (Input.GetKeyDown(KeyCode.X) && !isanimating)
        {
            animator.SetBool("istaking", true);
            Invoke("animationg", 3);
            return;
        }
        else
        {
            animator.SetBool("istaking", false);
        }

        if (inputaxis > 0 && facing_change == false && !isanimating)
        {
            Flip();
        }
        else if (inputaxis < 0 && facing_change == true && !isanimating)
        {
            Flip();
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isattacking", true);
            isanimating = true;
            Invoke("animationg", 3);
            return;
        }
        else
        {
            animator.SetBool("isattacking", false);
        }
        if (Input.GetMouseButtonDown(2))
        {
            animator.SetBool("isattacking2", true);
            isanimating = true;
            Invoke("animationg", 3);
            return;
        }
        else
        {
            animator.SetBool("isattacking2", false);
        }
        //isGrounded = Physics2D.OverlapCircle(ground_Check.position, checkRadius, what_Ground);



    }

    void Flip()
    {
        player_GFX.transform.localScale = new Vector3(-player_GFX.transform.localScale.x, player_GFX.transform.localScale.y, player_GFX.transform.localScale.z);
        if (facing_change)
        {
            player_GFX.transform.position = new Vector2(player_GFX.transform.position.x - 15, player_GFX.transform.position.y);
        }
        else
        {
            player_GFX.transform.position = new Vector2(player_GFX.transform.position.x + 15, player_GFX.transform.position.y);
        }

        facing_change = !facing_change;
    }

    void animationg()
    {


        isanimating = false;
    }
}
