using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{

    public GameObject doorOpen;
    private AudioSource soundKey;

    private void Awake()
    {
        soundKey = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        soundKey.Play();
        Destroy(doorOpen);
        Destroy(this.gameObject,0.3f);
    }
}
