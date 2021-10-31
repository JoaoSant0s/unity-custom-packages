using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class SimpleAudioObject : AudioObject
    {
        private AudioSource audioSource;
        public SimpleAudioObject(AudioSourceController controller, SimpleAudioAsset asset) : base(controller, asset) { }

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
            var asset = (SimpleAudioAsset) audioAsset;

            audioSource.clip = asset.clip;
            audioSource.volume = asset.volume;
            audioSource.outputAudioMixerGroup = asset.mixer;
        }

        #endregion

    }
}
