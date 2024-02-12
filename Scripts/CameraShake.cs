using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float timer = 0f;

        while (timer < shakeDuration)
        {
            timer += Time.deltaTime;               //Have to cast to Vector3 as cam position is vector 3.
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;   //Gives random pos within a circle of 1 * 0.5 (shake magnitude). Loop of random pos's will look like shake.

            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}

