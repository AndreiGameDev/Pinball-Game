using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    private static AudioManager _instance;
    public static AudioManager Instance {
        get {
            return _instance;
        }
    }
    [Header("Audio Source")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;
    [Header("SFX")]
    public AudioClip SFX_GolfballBump;
    public AudioClip SFX_GolfballDestroyed;
    public AudioClip SFX_ClickButton;
    public AudioClip SFX_ClappingWin;

    [Header("Music")]
    public AudioClip M_Win;
    [SerializeField] AudioClip M_MainMenu;
    [SerializeField] AudioClip M_Game;


    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start() {
        SceneManager.activeSceneChanged += OnSceneChange;
    }
    public void PlaySFX(AudioClip clip) {
        sfx.PlayOneShot(clip);
    }
    void OnSceneChange(Scene currentScene, Scene nextScene) {
        foreach(int i in PlayerLevelScenes.instance.GetPlayerLevelScenes()) {
            if(music.loop == false) {
                music.loop = true;
            }
            if(nextScene.buildIndex == i) {
                music.Stop();
                music.clip = M_Game;
                music.Play();
            } else if(nextScene.buildIndex == PlayerLevelScenes.instance.GetPlayerWinSceneIndex()){
                music.Stop();
                PlaySFX(SFX_ClappingWin);
            } else {
                music.Stop();
                music.clip = M_MainMenu;
                music.Play();
            }
        }
    }
}
