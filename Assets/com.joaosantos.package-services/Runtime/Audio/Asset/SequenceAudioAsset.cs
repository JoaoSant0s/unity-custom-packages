using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main.ServicePackage.Audio
{
    [CreateAssetMenu(fileName = "SequenceAudioAsset", menuName = "Main/Service/Audio/SequenceAudioAsset")]
    public class SequenceAudioAsset : AudioAsset
    {
        [Header("Objects")]
        public AudioClip[] clips;

        public AudioConditionAsset stopCondition;

        public override AudioObject Create() { return new SequenceAudioObject(); }

        public override bool CheckStopCondition(AudioConditionAsset asset)
        {
            return stopCondition == asset;
        }
    }
}