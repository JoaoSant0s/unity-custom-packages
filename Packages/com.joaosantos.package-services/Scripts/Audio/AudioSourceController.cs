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
        }

        #region Public Methods

        public AudioSource GetValidAudioSource()
        {
            var element = audioSourceInUse.FirstOrDefault( element => element.Value == false);
            AudioSource audioSource = element.Key;

            if(element.Key == null)
            {
                audioSource = CreateAudioSourceController();
            }

            audioSourceInUse[audioSource] = true;
            
            return audioSource;
        }

        public AudioSource CreateAudioSourceController()
        {
            var newGameObject = new GameObject();

            var audioSource = newGameObject.AddComponent<AudioSource>();

            newGameObject.transform.SetParent(audioService.transform);
            newGameObject.name = audioSource.GetType().Name;

            audioSourceInUse[audioSource] = false;

            return audioSource;
        }

        #endregion
    }
}