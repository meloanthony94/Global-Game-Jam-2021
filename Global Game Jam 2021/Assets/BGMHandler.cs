using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMHandler : MonoBehaviour
{
    [SerializeField]
    AudioSource myAudioSource;

    [SerializeField]
    AudioClip[] BGMClips;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void ChangeBGM(int index)
    {
        myAudioSource.Stop();
        myAudioSource.clip = BGMClips[index];
        myAudioSource.Play();
    }

    public void PlaySFX(int index)
    {
        myAudioSource.clip = BGMClips[index];
        myAudioSource.PlayOneShot(myAudioSource.clip);
    }
}
