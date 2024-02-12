using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    ChangeSprite changeSprite;
    ScoreKeeper scoreKeeper;

    UIController uiController;
    Flash[] flashes;
    CameraShake cameraShake;
    PlayerController playerController;

    AudioPlayer audioPlayer;

    bool damageable = true;
    void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();

        changeSprite = FindObjectOfType<ChangeSprite>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        uiController = FindObjectOfType<UIController>();
        flashes = FindObjectsOfType<Flash>();
        cameraShake = Camera.main.GetComponent<CameraShake>();   //Camera has this special way to get it's ref.

        playerController = FindObjectOfType<PlayerController>();

    }

    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Emerald"))
        {
            Destroy(collision.gameObject);
            uiController.DisplayInitialInstructions();
            changeSprite.AddGem('E');
        }
        if (collision.CompareTag("Gopherite"))
        {
            Destroy(collision.gameObject);
            uiController.DisplayInitialInstructions();
            changeSprite.AddGem('G');
        }
        if (collision.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            uiController.DisplayInitialInstructions();
            changeSprite.AddGem('Y');
        }
        if (collision.CompareTag("Obstacle"))
        {
            audioPlayer.PlayObstacleHitCart();
            ReduceLives(1, true, true);
        }
        if (collision.CompareTag("1UP"))
        {
            audioPlayer.PlayOneUp();
            ReduceLives(-1, false, false);
            Destroy(collision.gameObject);

        }

    }


    public void ReduceLives(int damage, bool shouldFlash, bool redOrGreen)
    {

        if (damageable)
        {
            damageable = false;
            scoreKeeper.UpdateLives(damage);

            if (shouldFlash)
            {
                cameraShake.Play();
                foreach (Flash flash in flashes)
                {
                    flash.TriggerFlash();
                }
            }

            uiController.ColourRedOrGreen(redOrGreen);


            if (scoreKeeper.GetLives() <= 0)
                playerController.Die();

            damageable = true;

        }



    }





}
