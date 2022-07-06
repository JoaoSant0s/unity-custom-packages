using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace JoaoSant0s.CustomVariable
{
    public abstract class Variable<T> : ScriptableObject
    {
        public T value;
    }
}
