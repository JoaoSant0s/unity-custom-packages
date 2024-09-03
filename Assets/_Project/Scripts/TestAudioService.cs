using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.Audio;
using JoaoSant0s.ServicePackage.General;

public class TestAudioService : MonoBehaviour
{
    
    [SerializeField]
    private AudioAsset musicAsset;

    [SerializeField]
    private AudioAsset sfxAsset;

    [SerializeField]
    private AudioConditionAsset stopMusicConditionAsset;

    private AudioService audioService;

    private bool musicMuted;
    private bool sfxMuted;

    void Start()
    {
        audioService = Services.Get<AudioService>();
        PlayMusic();
    }

    #region Private Methods

    private void PlayMusic()
    {
        audioService.Play(musicAsset);
        Debug.Log(musicAsset);
    }

    #endregion

    #region UI Methosd

    public void ToggleMuteMusic()
    {
        musicMuted = !musicMuted;
        Debug.Log(musicMuted);
        audioService.MuteMusic(musicMuted);
    }

    public void ToggleMuteSFX()
    {
        sfxMuted = !sfxMuted;
        Debug.Log(sfxMuted);
        audioService.MuteSfx(sfxMuted);
    }

    public void StopMusic()
    {
        audioService.Stop(stopMusicConditionAsset);
    }

    public void PlaySFX()
    {
        audioService.Play(sfxAsset);
    }

    #endregion

}
