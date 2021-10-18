using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class AudioObject
    {
        public bool started;

        public virtual void Play(AudioSource audioSource, AudioAsset asset, AudioService.TryUpdateMusic endLoopAction = null)
        {
            asset.Play(audioSource);
            started = true;
        }

        public virtual void Update() { }
    }
}