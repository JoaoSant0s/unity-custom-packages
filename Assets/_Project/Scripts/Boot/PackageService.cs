using System.Runtime.ConstrainedExecution;
using UnityEngine.SceneManagement;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Scenes;
using JoaoSant0s.ServicePackage.Screens;
using JoaoSant0s.ServicePackage.Popups;
using System.Linq;

public class PackageService : Service
{
    private SceneService sceneService;
    private ScreenService screenService;
    private PopupService popupService;

    private string startScene;
    private SharedPopup sharedPopup;

    public override void OnInit()
    {
        sceneService = Services.Get<SceneService>();
        screenService = Services.Get<ScreenService>();
        popupService = Services.Get<PopupService>();

        sceneService.OnActiveSceneChanged += OnActiveSceneChanged;
        startScene = sceneService.CurrentSceneName;
        CreateBootScreen();
    }

    public bool IsStartScene(string sceneName)
    {
        return sceneName.Equals(startScene);
    }

    public void ReturnToStartScene()
    {
        sceneService.Load(startScene);
    }

    private void OnActiveSceneChanged(Scene _, Scene next)
    {
        TryCloseSharePopup();

        if (startScene.Equals(next.name))
        {
            CreateBootScreen();
        }
        else
        {
            sharedPopup = popupService.Show<SharedPopup>();
        }
    }

    private void TryCloseSharePopup()
    {
        if (sharedPopup == null) return;

        sharedPopup.Close();
        sharedPopup = null;
    }

    private void CreateBootScreen()
    {
        screenService.GoToScreen<TestBootScreen>();
    }

}
