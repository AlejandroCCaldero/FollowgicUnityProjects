using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private int nCardsTaken;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        nCardsTaken = 0;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if(moveInput < 0)
        {
            transform.localScale = new Vector2(-0.75f, transform.localScale.y);
        }

        if(moveInput > 0)
        {
            transform.localScale = new Vector2(0.75f, transform.localScale.y);
        }

        transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed;
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(moveInput * speed)); //not working
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Card")
        {
            //Debug.Log("Carta cogida");
            Destroy(other.gameObject);
            SoundManager.PlaySound("normalSound");
            nCardsTaken++;
        }
        else if(other.gameObject.tag == "RareCard")
        {
            Destroy(other.gameObject);
            SoundManager.PlaySound("rareSound");  
            nCardsTaken = nCardsTaken + 2;  
        }
    }

    public int getCardsTaken()
    {
        return this.nCardsTaken;
    }
}
