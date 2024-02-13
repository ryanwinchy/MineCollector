using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHoly : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<AudioPlayer>().PlayHolySound();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
