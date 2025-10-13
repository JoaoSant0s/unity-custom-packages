using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Screens;
using UnityEngine;

public class Boot : MonoBehaviour
{
    void Start()
    {
        var screenService = Services.Get<ScreenService>();
        screenService.GoToScreen<TestBootScreen>();
    }

}
