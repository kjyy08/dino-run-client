using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [System.Serializable]
    public class AudioClipObject
    {
        [SerializeField] private string name;
        [SerializeField] private AudioClip clip;

        public string Name { get { return name; } }
        public AudioClip Clip { get { return clip; } }
    }

    [SerializeField] private AudioClipObject[] audioClipList;

    private AudioSource audioSource;
    private Dictionary<string, AudioClip> audioClips;
    private bool isGameOverSoundPlayed = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClips = new Dictionary<string, AudioClip>();
    }

    void Start()
    {
        SetAudioClips();
        isGameOverSoundPlayed = false;
    }

    void Update()
    {
        switch (GameManager.Instance.State)
        {
            case GameManager.GAME_STATE.PLAYING:
                ResumeAudio();
                break;

            case GameManager.GAME_STATE.PAUSED:
                PauseAudio();
                break;

            case GameManager.GAME_STATE.GAMEOVER:
                PlayGameOver();
                break;
        }
    }

    void SetAudioClips()
    {
        foreach (AudioClipObject clip in audioClipList)
        {
            audioClips.Add(clip.Name, clip.Clip);
        }
    }

    void PauseAudio()
    {
        audioSource.Pause();
    }

    void ResumeAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }

    void PlayGameOver()
    {
        if (isGameOverSoundPlayed)
            return;

        audioSource.Stop();
        PlayOneShotAudioClip("gameover");
        isGameOverSoundPlayed = true;
    }

    public void PlayOneShotAudioClip(string name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}