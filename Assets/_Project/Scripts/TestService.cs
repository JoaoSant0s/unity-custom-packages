using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Flag;

using JoaoSant0s.Extensions.Vectors;

public class TestService : MonoBehaviour
{
    [SerializeField]
    private FlagAsset assetFlag;

    private FlagService flagService;

    private void Start()
    {
        flagService = Services.Get<FlagService>();
    }

    #region UI Methods

    public void ActiveButton()
    {
        flagService.Raise(assetFlag);
    }

    public void DesactiveButton()
    {
        flagService.Lower(assetFlag);
    }

    #endregion
}
