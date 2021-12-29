using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSFXHandler : MonoBehaviour
{
    [System.Serializable]
    public struct CharacterAudio
    {
        [Header("Clips")]
        public AudioClip[] Level0YellGroup;

        public AudioClip[] Level1YellGroup;

        public AudioClip[] Level2YellGroup;

        public AudioClip[] Level3YellGroup;
    }

    CharacterAnimationHandler myAnimHandler;

    [SerializeField]
    ScreamHandler myScreamHandle;

    [SerializeField]
    AudioSource myAudioSource;

    [SerializeField]
    FloatReference modelChoice;

    [SerializeField]
    CharacterAudio[] CharacterSet;

    /*
    [Header("Clips")]
    [SerializeField]
    AudioClip[] Level0YellGroup;

    [SerializeField]
    AudioClip[] Level1YellGroup;

    [SerializeField]
    AudioClip[] Level2YellGroup;

    [SerializeField]
    AudioClip[] Level3YellGroup;
    */

    // Start is called before the first frame update
    void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAnimHandler = GetComponent<CharacterAnimationHandler>();
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
        if (myScreamHandle.isCoolingDown == false)
       {
            switch (myScreamHandle.CurrentScreamLevel)
            {
                case 0:
                    SelectYell(CharacterSet[(int)modelChoice.Value].Level0YellGroup);
                    break;

                case 1:
                    SelectYell(CharacterSet[(int)modelChoice.Value].Level1YellGroup);
                    break;

                case 2:
                    SelectYell(CharacterSet[(int)modelChoice.Value].Level2YellGroup);
                    break;

                case 3:
                    SelectYell(CharacterSet[(int)modelChoice.Value].Level3YellGroup);
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
        myAnimHandler?.BeginYell(myAudioSource.clip.length);

        Yell();
    }
}
