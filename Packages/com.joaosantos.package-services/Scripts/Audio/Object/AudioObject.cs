using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class AudioObject
    {
        public delegate void OnDisposeAudio(AudioObject audioObject);
        public OnDisposeAudio DisposeAudio;

        protected AudioSourceController audioController;
        protected AudioAsset audioAsset;

        public AudioObject(AudioSourceController controller, AudioAsset asset)
        {
            audioController = controller;
            audioAsset = asset;
        }

        public virtual void Play() { }

        public virtual void Update() { }

        public virtual void Stop() { }

        public virtual bool CheckStopCondition(AudioConditionAsset asset)
        {
            return false;
        }
        
    }
}