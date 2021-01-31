using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioStateManagerController : MonoBehaviour
{
    public enum AudioState
    {
        Idle,
        Playing,
        Win,
        Lose,
        Other
    }

    public AudioState audioState = AudioState.Idle;

    [SerializeField]
    private AudioSource _musicAudioSource;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (audioState)
        {
            case AudioState.Idle:
                if(_musicAudioSource.isPlaying)
                    _musicAudioSource.Stop();
                break;
            case AudioState.Playing:
                if(!_musicAudioSource.isPlaying)
                    _musicAudioSource.Play();
                break;
            case AudioState.Win:
                if(_musicAudioSource.isPlaying)
                    _musicAudioSource.Stop();
                
                GameObject.FindGameObjectWithTag("SFXAudioSource").GetComponent<SFXController>().Win();
                break;
            case AudioState.Lose:
                if(_musicAudioSource.isPlaying)
                    _musicAudioSource.Stop();
                
                GameObject.FindGameObjectWithTag("SFXAudioSource").GetComponent<SFXController>().Lose();
                break;
        }
    }
}
