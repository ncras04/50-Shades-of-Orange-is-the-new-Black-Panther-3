using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    AudioSource intro;
    [SerializeField]
    AudioSource loop;

    private void Awake()
    {
        if (FindObjectsOfType<Music>().Length > 1)
            Destroy(this.gameObject);

        return;
    }
    void Start()
    {
        intro.Play();
        loop.PlayDelayed(intro.clip.length);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
