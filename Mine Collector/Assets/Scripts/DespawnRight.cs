using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnRight : MonoBehaviour
{

    [SerializeField] bool right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > 8.3f && right)
            Destroy(gameObject);
        if (gameObject.transform.position.x < -3.4f && !right)
            Destroy(gameObject);

    }
}
