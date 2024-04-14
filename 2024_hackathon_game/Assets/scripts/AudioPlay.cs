using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource aud;

    void Start() {
        aud.GetComponent<AudioSource>();
        aud.Play();
    }
    void Update() {

    }
}