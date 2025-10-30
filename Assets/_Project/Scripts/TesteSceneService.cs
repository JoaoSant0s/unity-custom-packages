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

    private SceneService sceneService;

    private void Awake()
    {
        sceneService = Services.Get<SceneService>();
    }

    private void Start()
    {
        sceneService.OnLoadStarted += LoadStarted;
        sceneService.OnLoadAsyncStarted += OnLoadAsyncStarted;
        sceneService.OnSceneLoaded += OnSceneLoaded;
        sceneService.OnActiveSceneChanged += OnActiveSceneChanged;
        sceneService.OnSceneUnloaded += OnSceneUnloaded;
        sceneService.OnLoadCompleteAsyncScene += OnLoadCompleteAsyncScene;

        if (isLoadAsync)
        {
            sceneService.LoadAsync(sceneName, mode);
        }
        else
        {
            sceneService.Load(sceneName, mode);
        }
    }

    private void OnDestroy()
    {
        sceneService.OnLoadStarted -= LoadStarted;
        sceneService.OnLoadAsyncStarted -= OnLoadAsyncStarted;
        sceneService.OnSceneLoaded -= OnSceneLoaded;
        sceneService.OnActiveSceneChanged -= OnActiveSceneChanged;
        sceneService.OnSceneUnloaded -= OnSceneUnloaded;
        sceneService.OnLoadCompleteAsyncScene -= OnLoadCompleteAsyncScene;
    }

    private void LoadStarted(string sceneName) => Debugs.Log("OnLoadStarted", sceneName, false);
    private void OnLoadAsyncStarted(string sceneName) => Debugs.Log("OnLoadStarted", sceneName, true);    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) => Debugs.Log("OnSceneLoaded", scene, mode);
    private void OnActiveSceneChanged(Scene current, Scene next) => Debugs.Log("OnActiveSceneChanged", current, next);
    private void OnSceneUnloaded(Scene current) => Debugs.Log("OnSceneUnloaded", current);
    private void OnLoadCompleteAsyncScene(AsyncOperation operation) => Debugs.Log("OnLoadCompleteAsyncScene", operation);

}
