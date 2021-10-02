using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Main.ServicePackage.General;
using UnityEngine.Audio;

namespace Main.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "Main/Service/Audio/AudioConfig")]
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
