using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace JoaoSant0s.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "LoopAudioAsset", menuName = "JoaoSant0s/ServicePackage/Audio/LoopAudioAsset")]
    public class LoopAudioAsset : AudioAsset
    {
       [Header("Configs")]
        public AudioMixerGroup mixer;

        [Range(0f, 1f)]
        public float volume = 1;
        public AudioClip clip;
        public AudioConditionAsset stopCondition;

        public override AudioObject Create(AudioSourceController controller) { return new LoopAudioObject(controller, this); }
    }
}