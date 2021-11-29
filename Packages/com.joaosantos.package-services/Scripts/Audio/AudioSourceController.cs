using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class AudioSourceController
    {
        private AudioService audioService;

        private Dictionary<AudioSource, bool> audioSourceInUse;

        public AudioSourceController(AudioService service)
        {
            audioService = service;
            audioSourceInUse = new Dictionary<AudioSource, bool>();
            Setup();
        }

        #region Private Methods

        private void Setup()
        {
            for (int i = 0; i < audioService.Config.startAudioSourceAmount; i++)
            {
                CreateAudioSourceController();
            }
        }

        #endregion

        #region Public Methods

        public AudioSource GetUnlockedAudioSource()
        {
            var element = audioSourceInUse.FirstOrDefault(element => !element.Value);
            AudioSource audioSource = element.Key;

            if (element.Key == null)
            {
                audioSource = CreateAudioSourceController();
            }

            return audioSource;
        }

        public void LockAudioSource(AudioSource audioSource)
        {
            audioSource.gameObject.SetActive(true);
            audioSourceInUse[audioSource] = true;
        }

        public void UnlockAudioSource(AudioSource audioSource)
        {
            audioSource.clip = null;
            audioSource.loop = false;
            audioSource.volume = 1;
            audioSource.outputAudioMixerGroup = null;
            audioSource.gameObject.SetActive(false);
            audioSourceInUse[audioSource] = false;
        }

        public AudioSource CreateAudioSourceController()
        {
            var newGameObject = new GameObject();

            var audioSource = newGameObject.AddComponent<AudioSource>();

            newGameObject.transform.SetParent(audioService.transform);
            newGameObject.name = audioSource.GetType().Name;
            audioSource.gameObject.SetActive(false);
            audioSourceInUse[audioSource] = false;

            return audioSource;
        }

        #endregion
    }
}