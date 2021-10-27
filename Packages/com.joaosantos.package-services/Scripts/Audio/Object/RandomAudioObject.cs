using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.Extensions.Collections;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class RandomAudioObject : AudioObject
    {
        private AudioSource audioSource;

        public RandomAudioObject(AudioSourceController controller, RandomAudioAsset asset) : base(controller, asset){ }

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
            var asset = (RandomAudioAsset) audioAsset;

            audioSource.clip = asset.clips.Random();
            audioSource.loop = false;
            audioSource.volume = asset.volume;
            audioSource.outputAudioMixerGroup = asset.mixer;
        }
    }
}
