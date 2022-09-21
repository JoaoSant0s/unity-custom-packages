/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class AudioService : Service
    {
        public bool IsMusicMuted { get; protected set; }
        public bool IsSfxMuted { get; protected set; }
        public AudioConfig Config { get; protected set; }

        private AudioSourceController audioSourceController;

        private List<AudioObject> audioObjects;

        #region Unity Methods

        private void Update()
        {
            for (int i = 0; i < audioObjects.Count; i++)
            {
                audioObjects[i].Update();
            }
        }

        #endregion

        #region Override Methods
        public override void OnInit()
        {
            Config = Resources.Load<AudioConfig>("Configs/AudioConfig");
            Debug.Assert(Config != null, "Create the AudioConfig asset inside the path: Resources/Configs");
            Debug.Assert(Config != null, "RightClick/Create/JoaoSant0s/ServicePackage/Audio/AudioConfig");
            
            audioObjects = new List<AudioObject>();
            audioSourceController = new AudioSourceController(this);
        }

        #endregion

        #region Private Methods

        private List<AudioObject> GetAudioObject(AudioConditionAsset stopCondition)
        {
            return audioObjects.FindAll(a => a.CheckStopCondition(stopCondition));
        }

        private void RemoveAudioObject(AudioObject audioObject)
        {
            audioObject.DisposeAudio -= RemoveAudioObject;
            audioObjects.Remove(audioObject);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Mute music audio mixer      
        /// </summary>
        /// <param name="value"> state value </param>
        public void MuteMusic(bool value)
        {
            IsMusicMuted = value;

            Config.musicMixer.SetFloat(Config.exposedVolumeParameter, IsMusicMuted ? Config.lowerVolume : Config.upperMusicVolume);
        }

        /// <summary>
        /// Mute sfx audio mixer      
        /// </summary>
        /// <param name="value"> state value </param>
        public void MuteSfx(bool value)
        {
            IsSfxMuted = value;

            Config.sfxMixer.SetFloat(Config.exposedVolumeParameter, IsSfxMuted ? Config.lowerVolume : Config.upperSfxVolume);
        }

        /// <summary>
        /// Play a audio asset
        /// Audio Asset can be: Loop Audio, Random Audio or Simple Audio Asset      
        /// </summary>
        /// <param name="asset"> audio asset </param>
        public void Play(AudioAsset asset)
        {
            var audioObject = asset.Create(audioSourceController);
            audioObject.Play();
            audioObject.DisposeAudio += RemoveAudioObject;

            audioObjects.Add(audioObject);
        }

        /// <summary>
        /// Stop a audio asset by a condition
        /// </summary>
        /// <param name="stopCondition"> audio condition attached on Audio Asset </param>
        public void Stop(AudioConditionAsset stopCondition)
        {
            var audioObjects = GetAudioObject(stopCondition);

            for (int i = 0; i < audioObjects.Count; i++)
            {
                audioObjects[i]?.Stop();
            }
        }

        #endregion
    }
}