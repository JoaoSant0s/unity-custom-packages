using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.Extensions.Collections;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class RandomAudioObject : AudioObject
    {
        private AudioSource audioSource;
        private Thread audioSourceThread;

        public RandomAudioObject(AudioSourceController controller, RandomAudioAsset asset) : base(controller, asset){ }

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
            var asset = (RandomAudioAsset) audioAsset;

            audioSource.clip = asset.clips.Random();
            audioSource.volume = asset.volume;
            audioSource.outputAudioMixerGroup = asset.mixer;
        }

        #endregion
    }
}
