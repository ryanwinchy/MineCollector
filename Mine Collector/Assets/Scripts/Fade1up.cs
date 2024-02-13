using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade1up : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(rb);       //Removed RB, so freezes game object pos. Perhaps put in coroutine so rolls at first lol.

        StartCoroutine(DeleteMe());
        animator.SetBool("Fade", true);

    }

    IEnumerator DeleteMe()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }


}
