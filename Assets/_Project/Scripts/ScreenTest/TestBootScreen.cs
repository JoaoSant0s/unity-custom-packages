using UnityEngine;
using UnityEngine.UI;

using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.ServicePackage.Scenes;
using JoaoSant0s.ServicePackage.Screens;
using TMPro;
using UnityEngine.SceneManagement;

public class TestBootScreen : BaseScreen
{

    [SerializeField]
    private RectTransform content;

    [SerializeField]
    private Button baseButton;
    protected override void OnPrepare() { }

    protected override void OnRelease() { }

    void Start()
    {
        var sceneService = Services.Get<SceneService>();
        var screenService = Services.Get<ScreenService>();

        var scenesName = sceneService.GetAvailableSceneNames();

        for (int i = 0; i < scenesName.Length; i++)
        {
            var sceneName = scenesName[i];
            var button = Instantiate(baseButton, content);

            button.onClick.AddListener(() =>
            {
                sceneService.Load(sceneName, LoadSceneMode.Single);
                screenService.CloseScreen();
            });

            var buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.SetText(sceneName);
        }
    }
}
