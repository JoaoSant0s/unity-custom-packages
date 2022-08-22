using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

namespace JoaoSant0s.ServicePackage.Console
{    
    public class ConsoleManagerConfig : CustomScriptableObject<ConsoleManagerConfig>
    {
        [Header("Console Manager Config")]
        public bool IsThreaded;
    }    
}
