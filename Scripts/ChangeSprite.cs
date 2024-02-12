using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite currentSprite;
    string currentSpriteName;

    bool cartFull = false;
    bool cartEmpty = true;

    ScoreKeeper scoreKeeper;

    ParticleSystem sweat;
    ParticleSystem sweatRight;

    DetectCollisions detectCollisions;

    AudioPlayer audioPlayer;

    PlayerController playerController;
   
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        audioPlayer = FindObjectOfType<AudioPlayer>();

        detectCollisions = FindObjectOfType<DetectCollisions>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSprite = spriteRenderer.sprite;

        currentSpriteName = currentSprite.name;

        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        sweat = GameObject.Find("SweatParticle").GetComponent<ParticleSystem>();
        sweatRight = GameObject.Find("SweatParticleRight").GetComponent<ParticleSystem>();
    }

    
    void Update()
    {

           
    }

    public bool IsCartEmpty() => cartEmpty;

    public void AddGem(char gem)
    {
        audioPlayer.PlayGemHitCart();

        if (!cartFull)
        {
            currentSpriteName = GetNewSpriteName(currentSpriteName, gem);    //Update the sprite name to the new sprite.
            currentSprite = Resources.Load<Sprite>(currentSpriteName);    //Loads sprite from resources folder with the pngs.
            cartFull = CheckCartFull(currentSpriteName);
            spriteRenderer.sprite = currentSprite;
            PlayPauseSweat(cartFull);
        }
        else     //If cart is full, reduce lives and revert to empty cart. Design choice -- is this too easy? Maybe make them drop off still.
        {
            detectCollisions.ReduceLives(1, true, true);
            currentSpriteName = "XXX";
            currentSprite = Resources.Load<Sprite>(currentSpriteName);
            cartFull = CheckCartFull(currentSpriteName);
            spriteRenderer.sprite = currentSprite;
            PlayPauseSweat(cartFull);
        }
            

    }

    public void RemoveGem()
    {
        currentSpriteName = GetEmptySpriteName(currentSpriteName);
        cartFull = CheckCartFull(currentSpriteName);
        currentSprite = Resources.Load<Sprite>(currentSpriteName);    //Loads sprite from resources folder with the pngs.
        spriteRenderer.sprite = currentSprite;
        Debug.Log(cartFull);
        PlayPauseSweat(cartFull);
    }

     

    string GetNewSpriteName(string spriteName, char gem)
    {
        string newString ="";
        bool foundFirst = false;

        foreach (char letter in spriteName)
        {
            

            
            if (letter == 'X' && !foundFirst)
            {
                newString += gem;
                foundFirst = true;
            }
            else
                newString += letter;
        }
        

        return newString;
    }

    string GetEmptySpriteName(string spriteName)
    {
        Debug.Log(spriteName);
        char[] ch = spriteName.ToCharArray();   //Need to convert string to array of chars to cycle thru backwards.

        string newString = "";
        bool foundFirst = false;

        for (int i = ch.Length -1; i >= 0; i--) //Have to remove from right to left for sprites I made.
        {
            if (ch[i] != 'X' && !foundFirst)
            {
                scoreKeeper.AddScore(ch[i]);
                newString += 'X';
                foundFirst = true;
            }
            else
                newString += ch[i];
        }

        char[] newcharArray = newString.ToCharArray();   //Flip characters and return.
        Array.Reverse(newcharArray);

        Debug.Log(new string(newcharArray));
        return new string(newcharArray);
    }

    bool CheckCartFull(string spriteName)
    {
        int cnt = 0;

        foreach (char letter in spriteName)
        {
            if (letter != 'X')
                cnt++;
        }

        if (cnt >= 3)
        {
            cartFull = true;
            cartEmpty = false;
        }

        else if (cnt == 0)
        {
            cartFull = false;
            cartEmpty = true;
        }
        else
        {
            cartFull = false;
            cartEmpty = false;
        }
            
        

        return cartFull;


    }


    void PlayPauseSweat(bool play)
    {

        Debug.Log("PlayPauseSweat called with play = " + play);

        if (play)
        {
            playerController.SetMovementSpeed(2.5f);
            sweat.Play();
            sweatRight.Play();
        }
        else
        {
            playerController.SetMovementSpeed(5f);
            sweat.Stop();
            sweatRight.Stop();
        }
            
            
    }









    public bool GetCartFull() => cartFull;    //public getter.
}
