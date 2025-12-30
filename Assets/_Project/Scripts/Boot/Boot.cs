using JoaoSant0s.ServicePackage.General;
using UnityEngine;

public class Boot : MonoBehaviour
{
    void Start()
    {
        Services.Get<PackageService>();
    }

}
