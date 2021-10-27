using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace JoaoSant0s.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "SimpleAudioAsset", menuName = "JoaoSant0s/ServicePackage/Audio/SimpleAudioAsset")]
    public class SimpleAudioAsset : AudioAsset
    {
        [Header("Configs")]
        public AudioMixerGroup mixer;

        [Range(0f, 1f)]
        public float volume = 1;

        public AudioClip clip;

        public override AudioObject Create(AudioSourceController controller) { return new SimpleAudioObject(controller, this); }
    }
}