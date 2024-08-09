using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Flag;

using JoaoSant0s.CommonWrapper;

public class TestService : MonoBehaviour
{
    [SerializeField]
    private FlagAsset assetFlag;

    [SerializeField]
    private GameObject target;

    private FlagService flagService;
    private FlagActionObject flagAction;

    #region Unity Methods

    private void Awake()
    {
        flagService = Services.Get<FlagService>();
        flagAction = new(EnableTarget, DisableTarget);

        flagService.AddListening(assetFlag, flagAction);

        Debugs.Log(flagService.GetState(assetFlag));
    }

    private void OnDestroy()
    {
        flagService.RemoveListening(assetFlag, flagAction);
    }

    #endregion

    #region UI Methods

    public void ActiveButton()
    {
        flagService.Raise(assetFlag);

        Debugs.Log(flagService.GetState(assetFlag));
    }

    public void DesactiveButton()
    {
        flagService.Lower(assetFlag);
        Debugs.Log(flagService.GetState(assetFlag));
    }

    #endregion

    #region Private Methods

    private void EnableTarget()
    {
        target.SetActive(true);
    }

    private void DisableTarget()
    {
        target.SetActive(false);
    }

    #endregion
}
