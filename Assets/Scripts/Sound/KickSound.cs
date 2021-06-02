using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickSound : MonoBehaviour
{
    //Уничтожение аудио ресурса
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
