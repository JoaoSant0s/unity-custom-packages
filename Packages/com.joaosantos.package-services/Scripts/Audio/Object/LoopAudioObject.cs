using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class LoopAudioObject : AudioObject
    {
        private AudioSource audioSource;

        public LoopAudioObject(AudioSourceController controller, LoopAudioAsset asset) : base(controller, asset) { }

        #region Public Methods

        public override void Play()
        {
            audioSource = audioController.GetUnlockedAudioSource();
            audioController.LockAudioSource(audioSource);

            ConfigAudioSource();

            audioSource.Play();
        }

        public override void Stop() 
        { 
            audioSource.Stop();
            audioController.UnlockAudioSource(audioSource);
            DisposeAudio?.Invoke(this);
        }

        public override bool CheckStopCondition(AudioConditionAsset asset)
        {
            return ((LoopAudioAsset)audioAsset).stopCondition == asset;
        }

        #endregion

        #region Private Methods

        private void ConfigAudioSource()
        {
            var asset = (LoopAudioAsset) audioAsset;

            audioSource.clip = asset.clip;
            audioSource.loop = true;
            audioSource.volume = asset.volume;
            audioSource.outputAudioMixerGroup = asset.mixer;
        }

        #endregion

    }
}