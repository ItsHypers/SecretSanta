using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespeed;
    public float sprintspeed;
    private float speed;
    public Rigidbody2D rb;
    private Vector2 md;
    public Sprite backsprite;
    public Sprite forwardsprite;
    private SpriteRenderer spriteRenderer; 



    void Awake() {
        speed = movespeed; //Makes the speed default to move-speed, to allow them to start sprinting
        spriteRenderer = GetComponent<SpriteRenderer>(); //Get's the SpriteRenderer on the GameObject the script is on
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
        spriteRenderer.sprite = forwardsprite; // set the sprite to front sprite
    }
    
    void Update() //Update is a function that updates every second, but it is effected by frame-drops
    //This is why you only use it for stuff like sprinting and assigning inputs
    {
        ProcessInputs();

        if(Input.GetButtonDown("Shift"))
        {
            speed = sprintspeed;
        }
        if(Input.GetButtonUp("Shift"))
        {
            speed = movespeed;
        }
    }
    
    void FixedUpdate() 
    //Fixed updates is accurate with frames / drops, so is used for anything to do with
    //physics. (like walking)
    {
        Move();
    }
    void ProcessInputs() 
    //Assigns all the inputs used for walking
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        md = new Vector2(moveX, moveY).normalized;
        if (moveX == 1) 
        //If Player is moving Right. Do this
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else if (moveX == -1) 
        //If Player is moving Left. Do this
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        if (moveY == 1) 
        //If Player is moving Down. Do this
        {
            spriteRenderer.sprite = backsprite;
            //Sets Sprite to "back Sprite"
        }
        else if (moveY == -1) 
        //If Player is moving Up. Do this
        {
            spriteRenderer.sprite = forwardsprite;
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
    if (collision.gameObject.tag == "snowball")
        Debug.Log("test");
    }

    void Move()
    {
        rb.velocity = new Vector2 (md.x * speed, md.y * speed);
    }

}