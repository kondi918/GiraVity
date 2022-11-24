using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audio1;
    [SerializeField] AudioSource audio2;

    public void getAudio1() => audio1.Play(); 
    public void getAudio2() => audio2.Play(); 
    public void stopAudio1() => audio1.Stop(); 
    public void stopAudio2() => audio2.Stop(); 
}
