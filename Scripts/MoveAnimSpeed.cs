using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimSpeed : MonoBehaviour
{

    Animator animator;
    PlayerController playerController;
    float speed;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        ControlAnimation();


    }

    void ControlAnimation()
    {
        speed = -playerController.GetSpeed();
        animator.speed = Math.Abs(speed);

        if (Math.Abs(speed) > Mathf.Epsilon)        //If absolute speed is greater than 0.
            transform.localScale = new Vector2(Math.Sign(speed), 1);      //Flip based on if speed is + or -, to +1 or -1, this is what sign does.

       
    }
}



