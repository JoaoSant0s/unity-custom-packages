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
        var popup = popupService.Show<ExternalPopup>();
        popup.OnBeforeClose += () => { Debug.Log("Closing External Popup"); };
    }

    public void ShowInternalPopup()
    {
        if (popupService.IsPopupOpen<InternalPopup>()) return;
        var popup = popupService.Show<InternalPopup>((RectTransform)internalPopupArea);
        popup.OnBeforeClose += () => { Debug.Log("Closing Internal Popup"); };
    }

    #endregion

}
