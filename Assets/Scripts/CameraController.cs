using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject Prototype;
    public GameObject GreyGirl;
    public GameObject Door45;
    public Text text;

    GreyGirlCome GreyGirlCamera;

    public Animator animator;

    

    void Start()
    {
        GreyGirlCamera = GameObject.Find("GreyGirl").GetComponent<GreyGirlCome>();
        animator.SetInteger("Door45", 3);
        
    }

    void Update()
    {        
        transform.position = new Vector3(Prototype.transform.position.x, Prototype.transform.position.y-4, -20f);

        if (GreyGirlCamera.CameraChange )
        {
            transform.position = new Vector3(21, -3.3f, -20f);            

            if (GreyGirl.GetComponent<Transform>().position.x < 25)
            {
                animator.SetInteger("Door45", 0);
                text.transform.position = new Vector3(GreyGirl.transform.position.x, GreyGirl.transform.position.y + 4, -5f);
                text.text = "*Angry*";
            }

            if ( GreyGirl.GetComponent<Transform>().position.x < 21 )
            {
                
                transform.position = new Vector3(GreyGirl.transform.position.x, GreyGirl.transform.position.y - 2, -20f);
                animator.SetInteger("Door45", 2);
                text.text = "Hello, Prototype! How ar... Where are you?";
            }

            if (GreyGirlCamera.NextText)
            {
                text.text = " ";
            }
        }
    }
}


