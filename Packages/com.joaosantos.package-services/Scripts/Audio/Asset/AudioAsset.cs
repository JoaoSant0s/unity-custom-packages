using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

using NaughtyAttributes;

namespace Main.ServicePackage.Audio
{
    public class AudioAsset : ScriptableObject
    {
        [Header("General")]
        public AudioMixerGroup mixer;

        [Range(0f, 1f)]
        public float volume = 1;

        public virtual AudioObject Create() { return new AudioObject(); }

        public virtual void Play(AudioSource audioSource) { }

        public virtual bool CheckStopCondition(AudioConditionAsset asset)
        {
            return false;
        }
    }
}