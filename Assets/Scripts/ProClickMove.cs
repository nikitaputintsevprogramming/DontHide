
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProClickMove : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // скорость движения
    [SerializeField] private int lives = 5; // скорость движения
                                                

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private bool isHide = false;

    public static ProClickMove Instance { get; set; }


    public bool locker = false;
    public bool table = false;
    public bool bed = false;
    public bool wardrobe = false;

    private void OnTriggerStay2D(Collider2D otherObject)
    {
        otherObject.GetComponent<Renderer>().material.color = Color.gray;

        if (Input.GetKey(KeyCode.Space) && otherObject.gameObject.tag.Equals("Locker"))
        {
            locker = true;  
            ProClickMove.Instance.Hide();
        }

        if (Input.GetKey(KeyCode.Space) && otherObject.gameObject.tag.Equals("Table"))
        {
            table = true;
            ProClickMove.Instance.Hide();
        }

        if (Input.GetKey(KeyCode.Space) && otherObject.gameObject.tag.Equals("Bed"))
        {
            bed = true;
            ProClickMove.Instance.Hide();
        }

        if (Input.GetKey(KeyCode.Space) && otherObject.gameObject.tag.Equals("Wardrobe"))
        {
            wardrobe = true;
            ProClickMove.Instance.Hide();
        }

    }

    private void OnTriggerExit2D(Collider2D otherObject)
    {
        otherObject.GetComponent<Renderer>().material.color = Color.white;
    }


    public bool isReady()
    {
        return isHide;
    }

    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        isHide = true;
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        Instance = this;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

       
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //   if (isGrounded) State = States.PrototypeIdle;
        if (Input.GetButton("Horizontal"))
            Run();
        if (!Input.anyKey)
            State = States.PrototypeIdle;

    }

    private void FixedUpdate()
    {

    }

    private void Run()
    {
        //   if (isGrounded) State = States.ProRun;
        State = States.ProRun; // !!! убрать, когда делаешь прыжок (вверху команда) !!!
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    

}
public enum States
{
    PrototypeIdle,
    ProCrouchDown,
    ProJump,
    ProKnockBand,
    ProCrouchUp,
    ProClimbUp,
    ProClimbDown,
    ProScared,
    ProLookUp,
    ProRun
}


