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
        rb.velocity = new Vector2(inputaxis * speed, rb.velocity.y);
        if (inputaxis != 0)
        {
            animator.SetBool("iswalking", true);
        }
        else
        {
            animator.SetBool("iswalking", false);
        }

        if (inputaxis > 0 && facing_change == false)
        {
            Flip();
        }
        else if (inputaxis < 0 && facing_change == true)
        {
            Flip();
        }

        //isGrounded = Physics2D.OverlapCircle(ground_Check.position, checkRadius, what_Ground);


        
    }

    void Flip()
    {
       player_GFX.transform.localScale = new Vector3(player_GFX.transform.localScale.x, -player_GFX.transform.localScale.y, player_GFX.transform.localScale.z);
        facing_change = !facing_change;
    }
}
