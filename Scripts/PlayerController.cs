using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float upperBound = 2.6f;
    [SerializeField] float lowerBound = -6.5f;

    float speed;
    bool lockMovement = false;

    [SerializeField] float movementSpeed = 5f;

    public void LockMovement() => lockMovement = true;   //Setters
    public void UnlockMovement() => lockMovement = false;

    public void SetMovementSpeed(float changedSpeed) => movementSpeed = changedSpeed;

    public float GetSpeed() => speed;

    Animator gopherAnimator;
    Animator legAnimator;

    LevelManager levelManager;
    AudioPlayer audioPlayer;

    void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        gopherAnimator = GameObject.Find("PlayerGopher").GetComponent<Animator>();
        legAnimator = GameObject.Find("Leg").GetComponent<Animator>();

        levelManager = FindObjectOfType<LevelManager>();
    }


    void Update()
    {
        float oldPos = transform.position.x;
        Move();
        float newPos = transform.position.x;

        speed = CalcSpeed(oldPos, newPos);
    }


    void Move()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < lowerBound)
            mousePos.x = lowerBound;
        if (mousePos.x > upperBound)
            mousePos.x = upperBound;

        Vector2 targetPos = new Vector2(mousePos.x, -4f);

        if (!lockMovement)
            transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * movementSpeed);
        
            

    }

    /*
    void Move()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > lowerBound && mousePos.x < upperBound && !lockMovement)
            transform.position = new Vector2(mousePos.x, -4f);       //Lock in y, get x from mouse pos.



    }
    */


    float CalcSpeed(float oldPos, float newPos)
    {
        return ((newPos - oldPos)/Time.deltaTime)/2;    //2 to slow down movement speed.
    }


    public void Die()
    {
        LockMovement();
        audioPlayer.PlayDeathSound();
        gopherAnimator.SetTrigger("GopherDeath");
        GameObject.Find("Leg").GetComponent<MoveAnimSpeed>().enabled = false;
        GameObject.Find("BufferLeg").SetActive(false);
        legAnimator.speed = 0.8f;
        legAnimator.SetTrigger("DeadLeg");
        levelManager.LoadGameOver();
    }








}
