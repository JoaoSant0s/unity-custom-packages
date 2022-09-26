using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Scenes;
using JoaoSant0s.CommonWrapper;


public class TesteSceneService : MonoBehaviour
{
    [SerializeField]
    private bool isLoadAsync;

    [SerializeField]
    private string sceneName;

    [SerializeField]
    private LoadSceneMode mode;

    private void Start()
    {
        var service = Services.Get<SceneService>();

        service.OnLoadStarted += (string sceneName, bool isAsync) => { Debugs.Log("OnLoadStarted", sceneName, isAsync); };
        service.OnSceneLoaded += (Scene scene, LoadSceneMode mode) => { Debugs.Log("OnSceneLoaded", scene, mode); };
        service.OnActiveSceneChanged += (Scene current, Scene next) => { Debugs.Log("OnActiveSceneChanged", current, next); };
        service.OnSceneUnloaded += (Scene current) => { Debugs.Log("OnSceneUnloaded", current); };
        service.OnLoadCompleteAsyncScene += (AsyncOperation operation) => { Debugs.Log("OnLoadCompleteAsyncScene", operation); };

        if (isLoadAsync)
        {
            service.LoadAsync(sceneName, mode);
        }
        else
        {
            service.Load(sceneName, mode);
        }
    }
}
