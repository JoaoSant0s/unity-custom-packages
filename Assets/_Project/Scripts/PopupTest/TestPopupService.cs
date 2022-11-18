using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Popups;
using JoaoSant0s.CommonWrapper;

public class TestPopupService : MonoBehaviour
{
    [SerializeField]
    private Transform internalPopupArea;

    [SerializeField]
    private Transform internalReferencePopupArea;

    [SerializeField]
    private InternalPopup internalPopup;

    private PopupService popupService;

    void Start()
    {
        popupService = Services.Get<PopupService>();
    }

    #region UI Methods

    public void ShowOpenedPopups()
    {
        var popups = popupService.GetOpenedPopups<InternalPopup>();
        Debugs.Log(popups);
        var externalPopups = popupService.GetOpenedPopups<ExternalPopup>();
        Debugs.Log(externalPopups);
    }

    public void ShowExternalPopup()
    {
        var popup = popupService.Show<ExternalPopup>();
        popup.OnBeforeClose += () => { Debug.Log("Closing External Popup"); };
    }

    public void ShowInternalPopup()
    {
        var popup = popupService.Show<InternalPopup>((RectTransform)internalPopupArea);
        popup.OnBeforeClose += () => { Debug.Log("Closing Internal Popup"); };
    }

    public void ShowReferenceInternalPopup()
    {
        var popup = popupService.Show<InternalPopup>(internalPopup, (RectTransform)internalReferencePopupArea);
        popup.OnBeforeClose += () => { Debug.Log("Closing Internal Popup"); };
    }

    #endregion

}
