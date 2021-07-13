using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {
    public AudioSource audio;
    public bool crash = false;
    public bool death = false;

    public AudioClip crash_AU;
    public AudioClip death_AU;
    void Start() { audio = GetComponent<AudioSource>(); }
    void Update() {
        if(crash == true){
            crash = false;
            audio.clip = crash_AU;
            audio.Play();
        } if (death == true){
            death = false;
            audio.clip = death_AU;
            audio.Play();
        }
    }
}
