using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    AudioSource intro;
    [SerializeField]
    AudioSource loop;
    void Start()
    {
        intro.Play();
        loop.PlayDelayed(intro.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
