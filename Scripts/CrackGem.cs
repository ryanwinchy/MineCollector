using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackGem : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite cracked;
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] bool isGem;
    [SerializeField] bool reduceLife;

    [SerializeField] bool isLight;
    AudioPlayer audioPlayer;

    DetectCollisions detectCollisions;
 
    void Start()
    {
        detectCollisions = FindObjectOfType<DetectCollisions>();
        audioPlayer = FindObjectOfType<AudioPlayer>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

     
        
    }


    void Update()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (isGem)
        {
            audioPlayer.PlayGemCrack();
            if (reduceLife)
                detectCollisions.ReduceLives(1, true, true);
        }


        if (isLight)
            audioPlayer.PlayLightObstacleHitGround();
        else
            audioPlayer.PlayObstacleHitGround();

        Destroy(rb);       //Removed RB, so freezes game object pos. Perhaps put in coroutine so rolls at first lol.
        spriteRenderer.sprite = cracked;
        StartCoroutine(DeleteMe());
        animator.SetBool("Crack", true);
      
    }

    IEnumerator DeleteMe()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }



}
