﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespeed;
    public float sprintspeed;
    private float speed;
    private AudioSource AudioS;
    private int sounds;
    private float pitch;
    private float pan;
    public Rigidbody2D rb;
    private Vector2 md;
    private Sprite init;
    private string characterString;
    [SerializeField] int colorIndex;
    
    [SerializeField] public SpriteRenderer spriteRenderer; 
    [SerializeField] private Sprite[] initsprite;

    public Animator animator;
    bool IsBlue = false;
    bool IsGreen = false;
    bool IsOrange = false;
    bool IsRed = false;
    bool IsPink = false;
    bool IsDuck = false;

    [Header("List Of Characters")]
    [SerializeField] private List<CharList> characterList = new List<CharList>();

    [Header("List Of Audio Files")]
    [SerializeField] private List < AudioClips > audiofiles = new List < AudioClips > ();




    void Start()
    {
        GetColor();
    }
    void Awake() {
        speed = movespeed; //Makes the speed default to move-speed, to allow them to start sprinting
        //spriteRenderer = GetComponent<SpriteRenderer>(); //Get's the SpriteRenderer on the GameObject the script is on
         // if the sprite on spriteRenderer is null then
    }

    void GetColor()
    {
        int colorIndex = PlayerPrefs.GetInt("Color", 0);
        init = characterList[colorIndex].front;
        Debug.Log(init);
        spriteRenderer.sprite = init; // set the sprite to front sprite
        animator.SetInteger("Char", colorIndex);
        if(colorIndex == 0)
        {
            IsBlue = true;
            characterString = "Blue";
        }
        else if(colorIndex == 1)
        {
            IsGreen = true;
            characterString = "Green";
        }
        else if(colorIndex == 2)
        {
            IsOrange = true;
            characterString = "Orange";
        }
        else if(colorIndex == 3)
        {
            IsRed = true;
            characterString = "Red";
        }
        else if(colorIndex == 4)
        {
            IsPink = true;
            characterString = "Pink";
        }
        else if(colorIndex == 5)
        {
            IsDuck = true;
            characterString = "Duck";
        }
    }
    
    void Update() //Update is a function that updates every second, but it is effected by frame-drops
    //This is why you only use it for stuff like sprinting and assigning inputs
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            speed += sprintspeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            speed -= sprintspeed;
        }
        ProcessInputs();
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
        AnimSelection();
    }

    void AnimSelection()
    {
        if (md.y > 0) 
        //If Player is moving Down. Do this
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(characterString + "Back"))
            animator.Play(characterString + "Back");
        }
        else if (md.y < 0) 
        //If Player is moving Up. Do this
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(characterString + "Up"))
            animator.Play(characterString + "Up");
        }
        else if(md.x == 0)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(characterString + "Idle"))
            animator.Play(characterString + "Idle");
        }
        else if (md.x > 0) 
        //If Player is moving Right. Do this
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(characterString + "Left"))
            animator.Play(characterString + "Left");
            //transform.rotation = Quaternion.Euler(0,180,0);
            spriteRenderer.sprite = init;
        }
        else if (md.x < 0) 
        //If Player is moving Left. Do this
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(characterString + "Right"))
            animator.Play(characterString + "Right");
            //transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sounds = Random.Range(0, audiofiles.Count);
            pitch = Random.Range(0.2f, 1.0f);
            pan = Random.Range(-1.0f, 1.0f);
            AudioS = GetComponent<AudioSource>();
            AudioS.pitch = pitch;
            AudioS.panStereo = pan;
            AudioS.PlayOneShot(audiofiles[sounds].audio);   
        }
}

    void Move()
    {
        rb.velocity = new Vector2 (md.x * speed, md.y * speed);
    }

    [System.Serializable]
    public class CharList
    {
        public Sprite front;
        public Sprite back;
    }

    [System.Serializable]
	public class AudioClips { [SerializeField] public AudioClip audio;
	}

}