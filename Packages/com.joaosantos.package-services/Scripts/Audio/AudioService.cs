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
        public AudioConfig Config { get; protected set; }

        private AudioSourceController audioSourceController;

        private List<AudioObject> audioObjects;

        #region Unity Methods

        private void Update()
        {
            for (int i = 0; i < audioObjects.Count; i++)
            {
                audioObjects[i].Update();
            }
        }

        #endregion

        #region Override Methods
        public override void Init()
        {
            Config = Resources.Load<AudioConfig>("Configs/AudioConfig");
            audioObjects = new List<AudioObject>();
            audioSourceController = new AudioSourceController(this);
        }

        #endregion

        #region Private Methods

        private List<AudioObject> GetAudioObject(AudioConditionAsset stopCondition)
        {
            return audioObjects.FindAll(a => a.CheckStopCondition(stopCondition));
        }

        private void RemoveAudioObject(AudioObject audioObject)
        {
            audioObject.DisposeAudio -= RemoveAudioObject;
            audioObjects.Remove(audioObject);
        }

        #endregion

        #region Public Methods

        public void MuteMusic(bool value)
        {
            IsMusicMuted = value;

            Config.musicMixer.SetFloat(Config.exposedVolumeParameter, IsMusicMuted ? Config.lowerVolume : Config.upperMusicVolume);
        }

        public void MuteSfx(bool value)
        {
            IsSfxMuted = value;

            Config.sfxMixer.SetFloat(Config.exposedVolumeParameter, IsSfxMuted ? Config.lowerVolume : Config.upperSfxVolume);
        }

        public void Play(AudioAsset asset)
        {
            var audioObject = asset.Create(audioSourceController);
            audioObject.Play();
            audioObject.DisposeAudio += RemoveAudioObject;

            audioObjects.Add(audioObject);
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