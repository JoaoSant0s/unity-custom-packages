using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

namespace JoaoSant0s.ServicePackage.Audio
{
    public class AudioAsset : ScriptableObject
    {
        public virtual AudioObject Create(AudioSourceController controller) { return null; }
    }
}