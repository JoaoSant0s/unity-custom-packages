using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using JoaoSant0s.ServicePackage.General;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class AudioService : Service
    {
        public bool IsMusicMuted { get; protected set; }
        public bool IsSfxMuted { get; protected set; }
        private AudioConfig config;

        private AudioSourceController audioSourceController;

        private List<AudioObject> audioObjects;

        #region Override Methods
        protected override void Init()
        {
            config = Resources.Load<AudioConfig>("Configs/AudioConfig");
            audioObjects = new List<AudioObject>();
            audioSourceController = new AudioSourceController(this);

            Setup();
        }

        public override void Reset()
        {
            for (int i = 0; i < this.audioObjects.Count; i++)
            {
                this.audioObjects[i].Reset();
            }

            this.audioObjects.Clear();

            Setup();
        }

        #endregion

        #region Private Methods

        private void Setup()
        {
            for (int i = 0; i < this.config.startAudioSourceAmount; i++)
            {
                audioSourceController.CreateAudioSourceController();
            }
        }

        private List<AudioObject> GetAudioObject(AudioConditionAsset stopCondition)
        {
            return audioObjects.FindAll(a => a.CheckStopCondition(stopCondition));
        }

        #endregion

        #region Public Methods

        public void MuteMusic(bool value)
        {
            IsMusicMuted = value;

            this.config.musicMixer.SetFloat(config.exposedVolumeParameter, IsMusicMuted ? config.upperMusicVolume : config.lowerVolume);
        }

        public void MuteSfx(bool value)
        {
            IsSfxMuted = value;

            this.config.sfxMixer.SetFloat(config.exposedVolumeParameter, IsSfxMuted ? config.upperSfxVolume : config.lowerVolume);
        }

        public void Play(AudioAsset asset)
        {
            var audioObject = asset.Create(audioSourceController);
            audioObjects.Add(audioObject);
            audioObject.Play();
        }

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