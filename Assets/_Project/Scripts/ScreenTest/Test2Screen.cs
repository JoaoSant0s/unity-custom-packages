using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.Screens;

public class Test2Screen : BaseScreen
{
    protected override void OnPrepare()
    {
        Debugs.Log("OnPrepare", this.GetType());
    }

    protected override void OnRelease()
    {
        Debugs.Log("OnRelease", this.GetType());
    }
}
