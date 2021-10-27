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
            audioSource = audioController.GetValidAudioSource();

            ConfigAudioSource();

            audioSource.Play();
        }

        public override void Stop() 
        { 
            audioSource.Stop();
        }

        #endregion

        private void ConfigAudioSource()
        {
            var asset = (SimpleAudioAsset) audioAsset;

            audioSource.clip = asset.clip;
            audioSource.loop = false;
            audioSource.volume = asset.volume;
            audioSource.outputAudioMixerGroup = asset.mixer;
        }
    }
}
