using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip normalSound, rareSound;
    private static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        normalSound = Resources.Load<AudioClip>("normalSound");
        rareSound = Resources.Load<AudioClip>("rareSound");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "normalSound":
                audioSrc.PlayOneShot(normalSound);
                break;

            case "rareSound":
                audioSrc.PlayOneShot(rareSound);
                break;    
        }
    }
}
