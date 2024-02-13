using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpell : MonoBehaviour
{
    [SerializeField] GameObject wizard;
    ChangeSprite changeSprite;
    PlayerController playerController;

    [SerializeField] float emptyTime = 0.2f;

    UIController uiController;
    AudioPlayer audioPlayer;

    bool inRange;
    bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        uiController = FindObjectOfType<UIController>();
        changeSprite = FindObjectOfType<ChangeSprite>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inRange && !pressed && !changeSprite.IsCartEmpty())
        {
            StartCoroutine(CastSpell());
        }
            
    }

    IEnumerator CastSpell()
    {
        audioPlayer.PlayEmptySound();
        pressed = true;
        uiController.ClearInstructions();
        playerController.LockMovement();
        wizard.GetComponent<Animator>().SetBool("spellCast", true);
        changeSprite.RemoveGem();
        yield return new WaitForSeconds(emptyTime);
        playerController.UnlockMovement();
        pressed = false;
    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
             inRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            inRange = false;
    }

}
