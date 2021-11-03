using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Popup;

public class TestPopupService : MonoBehaviour
{
    [SerializeField]
    private Transform internalPopupArea;
    private PopupService popupService;

    void Start()
    {
        popupService = Services.Get<PopupService>();
    }

    #region UI Methods

    public void ShowExternalPopup()
    {
        popupService.Show<ExternalPopup>();
    }

    public void ShowInternalPopup()
    {
        popupService.Show<InternalPopup>((RectTransform)internalPopupArea);
    }

    #endregion

}
