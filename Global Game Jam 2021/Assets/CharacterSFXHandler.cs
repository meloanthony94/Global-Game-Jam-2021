using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSFXHandler : MonoBehaviour
{
    [SerializeField]
    ScreamHandler myScreamHandle;

    [SerializeField]
    AudioSource myAudioSource;

    [Header("Clips")]
    [SerializeField]
    AudioClip[] Level0YellGroup;

    [SerializeField]
    AudioClip[] Level1YellGroup;

    [SerializeField]
    AudioClip[] Level2YellGroup;

    [SerializeField]
    AudioClip[] Level3YellGroup;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Yell()
    {
        myAudioSource.PlayOneShot(myAudioSource.clip, Random.Range(0.9f, 1.0f));
    }

    public void SelectYellGroup()
    {
        if (myScreamHandle.isScreaming == false && myScreamHandle.isCoolingDown == false)
       {
            switch (myScreamHandle.CurrentScreamLevel)
            {
                case 0:
                    SelectYell(Level0YellGroup);
                    break;

                case 1:
                    SelectYell(Level1YellGroup);
                    break;

                case 2:
                    SelectYell(Level2YellGroup);
                    break;

                case 3:
                    SelectYell(Level3YellGroup);
                    break;

                default:
                    break;
            }
        }
    }

    void SelectYell(AudioClip[] clips)
    {
        int index = Random.Range(0, clips.Length);
        myAudioSource.clip = clips[index];

        Yell();
    }
}
