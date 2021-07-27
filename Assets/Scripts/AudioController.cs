using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : Singleton<AudioController>
{
    public AudioSource musicAus;
    public AudioSource soundAus;

    public AudioClip rightAnsSound;
    public AudioClip badAnsSound;
    public AudioClip consultAudienceSound;
    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void PlayBgMusic()
    {
        musicAus.Play();
    }

    public void StopBgMusic()
    {
        musicAus.Stop();
    }

    public void PlayAskAudienceMusic()
    {
        soundAus.PlayOneShot(consultAudienceSound);
    }

    public void StopAskAudienceMusic()
    {
        soundAus.Stop();
    }

    public void PlaySound(AudioClip sound)
    {
        soundAus.PlayOneShot(sound);
    }

    public void ChangeSoundVolume(Slider volumeSlider)
    {
        soundAus.volume = volumeSlider.value;
    }

    public void ChangeMusicVolume(Slider volumeSlider)
    {
        musicAus.volume = volumeSlider.value;
    }
}
