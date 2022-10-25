using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource[] sfx;

    private void Start()
    {
        instance = this;
    }

    public void PlayFootStep()
    {
        if(!sfx[0].isPlaying == true)
        {
            sfx[0].pitch = Random.Range(.8f, 1.2f);
            sfx[0].Play();
        }
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }

    public void PlayRandomPitchSFX(int sfxToRandom)
    {
        sfx[sfxToRandom].pitch = Random.Range(.8f, 1.2f);
        PlaySFX(sfxToRandom);
    }
}
