using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class AudioObject
    {
        protected AudioAsset audioAsset;
        protected AudioSourceController audioController;

        public AudioObject(AudioSourceController controller, AudioAsset asset)
        {
            audioController = controller;
            audioAsset = asset;
        }

        public virtual void Play() { }

        public virtual void Reset() { }

        public virtual void Stop() { }

        public virtual bool CheckStopCondition(AudioConditionAsset asset)
        {
            return false;
        }
    }
}