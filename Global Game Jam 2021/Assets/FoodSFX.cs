using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSFX : MonoBehaviour
{
    [SerializeField]
    AudioClip[] clips;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        int index = Random.Range(0, clips.Length);
        myAudioSource.PlayOneShot(clips[index], Random.Range(0.9f, 1.0f));
    }
}
