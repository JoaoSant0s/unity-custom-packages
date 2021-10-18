using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class SequenceAudioObject : AudioObject
    {
        private int clipIndex = 0;

        private SequenceAudioAsset sequenceAudioAsset;

        private AudioSource audioSource;

        private AudioService.TryUpdateMusic endLoopEvent;

        public override void Play(AudioSource source, AudioAsset asset, AudioService.TryUpdateMusic endLoopAction = null)
        {
            sequenceAudioAsset = (SequenceAudioAsset)asset;
            endLoopEvent = endLoopAction;

            audioSource = source;
            audioSource.loop = false;
            audioSource.clip = sequenceAudioAsset.clips[clipIndex];
            audioSource.volume = sequenceAudioAsset.volume;
            audioSource.outputAudioMixerGroup = sequenceAudioAsset.mixer;

            audioSource.Play();
            started = true;
        }

        public override void Update()
        {
            if (!started) return;

            if (audioSource.isPlaying) return;

            var jumpInteraction = endLoopEvent?.Invoke();

            if (jumpInteraction.Value) return;

            NextClipIndex();

            audioSource.clip = sequenceAudioAsset.clips[clipIndex];
            audioSource.Play();
        }

        private void NextClipIndex()
        {
            clipIndex++;

            if (clipIndex >= sequenceAudioAsset.clips.Length)
            {
                clipIndex = 0;
            }
        }
    }
}