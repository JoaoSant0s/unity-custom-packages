using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

using DG.Tweening;

namespace Main.ServicePackage.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceController : MonoBehaviour
    {
        private AudioSource audioSource;

        private AudioAsset savedAsset;

        private AudioObject audioObject;

        public bool IsPlaying => audioSource.isPlaying;

        #region Unity Methods
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        #endregion

        #region Public Methods

        public void Reset()
        {
            Destroy(this.audioSource.gameObject);
        }

        public void Play(AudioAsset asset, AudioService.TryUpdateMusic endLoopAction = null)
        {
            savedAsset = asset;
            audioObject = asset.Create();

            audioObject.Play(audioSource, asset, endLoopAction);
        }

        public bool CheckStopCondition(AudioConditionAsset asset)
        {
            if (savedAsset == null) return true;

            return savedAsset.CheckStopCondition(asset);
        }

        public bool CheckSameAsset(AudioAsset asset)
        {
            return savedAsset == asset;
        }

        private void Update()
        {
            if (audioObject == null) return;

            audioObject.Update();
        }

        public void Stop()
        {
            savedAsset = null;
            audioObject = null;
            
            audioSource.Stop();
        }

        public void StopFade(float duration)
        {
            savedAsset = null;
            audioObject = null;

            audioSource.DOFade(0, duration).SetUpdate(true).OnComplete(() => { audioSource.Stop(); });
        }

        #endregion
    }
}