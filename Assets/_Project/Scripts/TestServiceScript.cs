using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Flag;

public class TestServiceScript : MonoBehaviour
{

    [SerializeField]
    private FlagAsset assetFlag;

    #region UI Methods

    public void ActiveButton()
    {
        Services.Get<FlagService>().Raise(assetFlag);
    }

    public void DesactiveButton()
    {
        Services.Get<FlagService>().Lower(assetFlag);
    }

    #endregion
}
