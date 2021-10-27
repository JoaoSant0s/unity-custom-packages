using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using JoaoSant0s.Extensions.Collections;
namespace JoaoSant0s.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "RandomAudioAsset", menuName = "JoaoSant0s/ServicePackage/Audio/RandomAudioAsset")]
    public class RandomAudioAsset : AudioAsset
    {
        [Header("Objects")]

        public List<AudioClip> clips;

        public override void Play(AudioSource audioSource)
        {
            audioSource.clip = clips.Random();
            audioSource.loop = false;
            audioSource.volume = volume;
            audioSource.outputAudioMixerGroup = mixer;
            audioSource.Play();
        }

    }
}