using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Popup;

public class TestPopupService : MonoBehaviour
{
    private PopupService popupService;

    void Start()
    {
        popupService = Services.Get<PopupService>();
    }

    #region UI Methods

    public void ShowExternalPopup()
    {
        popupService.ShowPopup<ExternalPopup>();
    }

    public void ShowInternalPopup()
    {
        popupService.ShowPopup<InternalPopup>();
    }

    #endregion

}
