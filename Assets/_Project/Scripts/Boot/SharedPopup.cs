using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Popups;
using UnityEngine;
using UnityEngine.UI;

public class SharedPopup : PopupBehaviour
{

    [SerializeField]
    private Button actionButton;

    void Awake()
    {
        actionButton.onClick.AddListener(() => Services.Get<PackageService>().ReturnToStartScene());
    }
}
