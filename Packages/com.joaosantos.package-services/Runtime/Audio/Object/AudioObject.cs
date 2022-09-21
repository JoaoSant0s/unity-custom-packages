/*
Copyright (c) 2021, Joao Santos
All rights reserved.

This source code is licensed under the BSD-style license found in the
LICENSE file in the root directory of this source tree.
*/

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