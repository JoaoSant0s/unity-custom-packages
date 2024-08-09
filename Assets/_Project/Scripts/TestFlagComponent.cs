using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.Flag;
using JoaoSant0s.ServicePackage.General;

public class TestFlagComponent : MonoBehaviour, FlagAction
{
    [SerializeField]
    private FlagAsset assetFlag;

    [SerializeField]
    private GameObject target;

    private FlagService flagService;

    #region Unity Methods

    private void Awake()
    {
        flagService = Services.Get<FlagService>();

        flagService.AddListening(assetFlag, this);
    }

    private void OnDestroy()
    {
        flagService.RemoveListening(assetFlag, this);
    }

    #endregion

    public void Lower()
    {
        target.SetActive(false);
    }

    public void Raise()
    {
        target.SetActive(true);
    }
}
