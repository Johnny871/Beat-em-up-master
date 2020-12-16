using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>{

    private AudioSource[] audioSource;
    [SerializeField] private AudioClip[] clips = new AudioClip[0];

    void Start()
    {
        audioSource = this.gameObject.GetComponents<AudioSource>();
    }

    public void Jump(){
        audioSource[0].PlayOneShot(clips[0]);
    }
    public void GetCoin(){
        audioSource[0].PlayOneShot(clips[1]);
    }
    public void Hit(){
        audioSource[0].PlayOneShot(clips[2]);
    }
    public void ThrowSword(){
        audioSource[0].PlayOneShot(clips[3]);
    }
}
