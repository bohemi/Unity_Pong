using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance {  get; private set; }
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    public void wallSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
    public void batSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
    public void upDownWallsSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}