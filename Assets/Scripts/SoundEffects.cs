using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] farts;
    [SerializeField] private AudioClip[] voices;
   
    private bool isVoicePlaying;
    private float voiceClipStartTime;
    private float voiceClipEndTime;
    private AudioClip previousFart;
    private AudioClip previousVoice;
    
    private void Update()
    {
        CheckClipEnded();
    }

    public void PlayRandom()
    {
        AudioClip randomFartClip;
        AudioClip randomVoiceClip;
        randomFartClip = farts[Random.Range(0, farts.Length)];
        randomVoiceClip = voices[Random.Range(0, voices.Length)];
        
        PlayAudioClips(randomFartClip, randomVoiceClip); 
        
    }
    
    private void PlayAudioClips(AudioClip fart, AudioClip voice)
    {
        audioSource.PlayOneShot(fart);
        
        if (!isVoicePlaying)
        {
            audioSource.PlayOneShot(voice);
            isVoicePlaying = true;
            voiceClipStartTime = Time.time;
            voiceClipEndTime = voice.length;
        }
    }
    
    private void CheckClipEnded()
    {
        if (isVoicePlaying && Time.time - voiceClipStartTime >= voiceClipEndTime)
        {
            isVoicePlaying = false;
        }
    }
}
