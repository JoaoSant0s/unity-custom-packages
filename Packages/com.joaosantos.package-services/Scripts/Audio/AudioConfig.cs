using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using UnityEngine.Audio;

namespace JoaoSant0s.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "JoaoSant0s/ServicePackage/Audio/AudioConfig")]
    public class AudioConfig : ServiceConfig
    {
        [Header("Audio Mixer")]
        public AudioMixer musicMixer;
        public AudioMixer sfxMixer;

        [Header("Properties")]
        public int startAudioSourceAmount;

        public string exposedVolumeParameter = "Volume";

        public int upperMusicVolume;
        public int upperSfxVolume;
        public int lowerVolume;
    }
}
