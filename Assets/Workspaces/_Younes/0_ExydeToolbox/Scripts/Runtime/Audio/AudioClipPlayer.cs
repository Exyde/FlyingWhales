using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioClipPlayer{
    public static void PlaySound(AudioClip clip, float volume = 1.0f){
        GameObject go = new GameObject();
        AudioSource ad = go.AddComponent<AudioSource>();
        ad.clip = clip;
        ad.volume = volume;
        ad.Play();
        MonoBehaviour.Destroy(go, clip.length);
    }

    public static void PlaySoundRandomFromArray(AudioClip[] clips, float volume = 1.0f){
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        PlaySound(clip, volume);
    }
}
