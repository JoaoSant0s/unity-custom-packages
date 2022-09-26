/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;
using UnityEngine.Audio;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "AudioConfig", menuName = "JoaoSant0s/ServicePackage/Audio/AudioConfig")]
    public class AudioConfig : CustomScriptableObject<AudioConfig>
    {
        [Header("Audio Config", order = 1)]

        [Header("Audio Mixer", order = 2)]
        public AudioMixer musicMixer;
        public AudioMixer sfxMixer;

        [Header("Properties", order = 3)]
        public int startAudioSourceAmount = 4;

        public string exposedVolumeParameter = "Volume";

        public int upperMusicVolume;
        public int upperSfxVolume = 2;
        public int lowerVolume = -80;
    }
}
