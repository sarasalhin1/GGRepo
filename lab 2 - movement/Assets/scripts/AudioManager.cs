using UnityEngine;
using System.Collections;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip overworldMusic;
    public AudioClip caveMusic;


    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
    }

    void Start() {
        musicSource.clip = overworldMusic;
        musicSource.Play(); 
    }

    public void PlayMusicsfx(AudioClip clip) {
            sfxSource.clip = clip;
            sfxSource.Play();
        }
    public void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
