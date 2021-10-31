using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

namespace JoaoSant0s.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "RandomAudioAsset", menuName = "JoaoSant0s/ServicePackage/Audio/RandomAudioAsset")]
    public class RandomAudioAsset : AudioAsset
    {
        [Header("Configs")]
        public AudioMixerGroup mixer;

        [Range(0f, 1f)]
        public float volume = 1;
        public List<AudioClip> clips;

        public override AudioObject Create(AudioSourceController controller) { return new RandomAudioObject(controller, this); }
    }
}