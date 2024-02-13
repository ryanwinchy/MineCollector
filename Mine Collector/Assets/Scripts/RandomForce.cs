using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    [Header("Force Boundaries")]
    [SerializeField] float xUpper = -280f;
    [SerializeField] float xLower = -67f;
    [SerializeField] float yUpper = 500f;
    [SerializeField] float yLower = 330f;

    [SerializeField] bool hasRotation;
    float lowerRotation = -1.14f;
    float upperRotation = 1.14f;

    [SerializeField] bool hasScaling;
    float lowerScale = 0.8f;
    float upperScale = 1.2f;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float x = Random.Range(xUpper, xLower);     //Get random force vals.
        float y = Random.Range(yUpper, yLower);

        Vector2 applyRandomForce = new Vector2(x, y);

        float randomRotationForce = Random.Range(lowerRotation, upperRotation);
        float randomScale = Random.Range(lowerScale, upperScale);

        if (hasScaling)
            gameObject.transform.localScale = new Vector2(randomScale, randomScale);

        rb.AddForce(applyRandomForce);

        if (hasRotation)
            rb.AddTorque(randomRotationForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }
}
