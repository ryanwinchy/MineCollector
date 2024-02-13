using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [Tooltip("Material to switch to during the flash.")]
    [SerializeField] Material flashMaterial;

    [Tooltip("How many times to flash.")]
    [SerializeField] int repetitions;

    [Tooltip("Duration of each flash")]
    [SerializeField] float duration;

    SpriteRenderer spriteRenderer;
    Material originalMaterial;
    //Coroutine flashRoutine;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }


    public void TriggerFlash()
    {
        StartCoroutine(FlashRoutine());
    }


    IEnumerator FlashRoutine()
    {
        for (int i =1; i <= repetitions; i++)
        {
            spriteRenderer.material = flashMaterial;  //Change to flash mat.
            yield return new WaitForSeconds(duration);
            spriteRenderer.material = originalMaterial;  //Change back.
            yield return new WaitForSeconds(duration);
        }


    }

}
