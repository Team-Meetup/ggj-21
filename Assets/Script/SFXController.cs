using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField]

    private AudioSource[] _audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // element 0
    public void Walk()
    {
        if(!_audioSource[0].isPlaying)
            _audioSource[0].Play();
    }

    // element 1
    public void Jump()
    {
        if(!_audioSource[1].isPlaying)
          _audioSource[1].Play();
    }

    // element 2
    public void IceCubeHit()
    {
        if(!_audioSource[2].isPlaying)
          _audioSource[2].Play();
    }

    // element 3
    public void FruitHit()
    {
        if(!_audioSource[3].isPlaying)
           _audioSource[3].Play();
    }
    
    // element 4
    public void Win()
    {
        if(!_audioSource[4].isPlaying)
            _audioSource[4].Play();
    }
    
    // element 5
    public void Lose()
    {
        if(!_audioSource[5].isPlaying)
            _audioSource[5].Play();
    }
}
