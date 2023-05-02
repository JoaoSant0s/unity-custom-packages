/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

using UnityEngine;

using JoaoSant0s.Extensions.Collections;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class RandomAudioObject : AudioObject
    {
        private AudioSource audioSource;

        public RandomAudioObject(AudioSourceController controller, RandomAudioAsset asset) : base(controller, asset) { }

        #region Public Methods

        public override void Play()
        {
            audioSource = audioController.GetUnlockedAudioSource();
            audioController.LockAudioSource(audioSource);

            ConfigAudioSource();

            audioSource.Play();
        }

        public override void Update()
        {
            if (audioSource.isPlaying) return;

            Stop();
        }

        public override void Stop()
        {
            audioSource.Stop();
            audioController.UnlockAudioSource(audioSource);
            DisposeAudio?.Invoke(this);
        }

        #endregion

        #region Private Methods

        private void ConfigAudioSource()
        {
            var asset = (RandomAudioAsset)audioAsset;

            audioSource.clip = asset.clips.Random();
            audioSource.volume = asset.volume;
            audioSource.outputAudioMixerGroup = asset.mixer;
        }

        #endregion
    }
}
