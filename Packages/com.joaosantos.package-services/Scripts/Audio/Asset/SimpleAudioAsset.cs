using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Main.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "SimpleAudioAsset", menuName = "Main/Service/Audio/SimpleAudioAsset")]
    public class SimpleAudioAsset : AudioAsset
    {
        [Header("Objects")]
        public AudioClip clip;

        public override void Play(AudioSource audioSource)
        {
            audioSource.clip = clip;
            audioSource.loop = false;
            audioSource.volume = volume;
            audioSource.outputAudioMixerGroup = mixer;
            audioSource.Play();
        }

    }
}