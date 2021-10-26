using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class AudioService : Service
    {
        public delegate bool TryUpdateMusic();

        public bool IsMusicMuted { get; set; }
        public bool IsSfxMuted { get; set; }
        private AudioConfig config;

        private List<AudioSourceController> audioSources;

        #region Override Methods
        protected override void Init()
        {
            this.config = Resources.Load<AudioConfig>("Configs/AudioConfig");
            this.audioSources = new List<AudioSourceController>();

            ToggleMusic();
            ToggleSfx();

            Setup();
        }

        public override void Reset()
        {
            for (int i = 0; i < this.audioSources.Count; i++)
            {
                this.audioSources[i].Reset();
            }

            this.audioSources.Clear();

            Setup();
        }

        #endregion

        #region Private Methods

        private void Setup()
        {
            for (int i = 0; i < this.config.startAudioSourceAmount; i++)
            {
                CreateAudioSourceController();
            }
        }

        private AudioSourceController CreateAudioSourceController()
        {
            var newGameObject = new GameObject();

            var audioSource = newGameObject.AddComponent<AudioSourceController>();

            newGameObject.transform.SetParent(transform);
            newGameObject.name = audioSource.GetType().Name;

            audioSources.Add(audioSource);

            return audioSource;
        }

        private AudioSourceController GetValidAudioSourceController()
        {
            var audioSource = audioSources.Find(a => !a.IsPlaying);

            if (audioSource == null)
            {
                audioSource = CreateAudioSourceController();
            }

            return audioSource;
        }

        private AudioSourceController GetAudioSourceController(AudioConditionAsset stopCondition)
        {
            var audioSource = audioSources.Find(a => a.CheckStopCondition(stopCondition));

            return audioSource;
        }

        private bool IsAudioSourceInUse(AudioAsset asset)
        {
            var audioSource = audioSources.Find(a => a.CheckSameAsset(asset));
            return audioSource != null;
        }

        #endregion

        #region Public Methods

        public void ToggleMusic()
        {
            IsMusicMuted = !IsMusicMuted;

            this.config.musicMixer.SetFloat(config.exposedVolumeParameter, IsMusicMuted ? config.upperMusicVolume : config.lowerVolume);
        }

        public void ToggleSfx()
        {
            IsSfxMuted = !IsSfxMuted;

            this.config.sfxMixer.SetFloat(config.exposedVolumeParameter, IsSfxMuted ? config.upperSfxVolume : config.lowerVolume);
        }

        public void Play(AudioAsset asset, bool unique = false, TryUpdateMusic endLoopAction = null)
        {
            if (unique)
            {
                if (IsAudioSourceInUse(asset)) return;
            }

            var audioSource = GetValidAudioSourceController();
            audioSource.Play(asset, endLoopAction: endLoopAction);
        }

        public void Stop(AudioConditionAsset stopCondition)
        {
            var audioSource = GetAudioSourceController(stopCondition);
            
            audioSource?.Stop();
        }

        #endregion

    }
}