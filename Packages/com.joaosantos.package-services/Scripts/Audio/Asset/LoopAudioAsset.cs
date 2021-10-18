using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace JoaoSant0s.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "LoopAudioAsset", menuName = "Main/Service/Audio/LoopAudioAsset")]
    public class LoopAudioAsset : AudioAsset
    {
        [Header("Objects")]
        public AudioClip clip;
        public AudioConditionAsset stopCondition;     

        public override void Play(AudioSource audioSource)
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.volume = volume;
            audioSource.outputAudioMixerGroup = mixer;
            audioSource.Play();
        }

        public override bool CheckStopCondition(AudioConditionAsset asset)
        {
            return stopCondition == asset;
        }
    }
}