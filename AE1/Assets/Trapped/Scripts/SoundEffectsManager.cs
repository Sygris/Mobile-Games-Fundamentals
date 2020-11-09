using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager SFXManager;

    public enum SFXType
    {
        Beep, Correct, Incorrect
    }

    public List<SFXType> ClipName = new List<SFXType>();
    public List<AudioClip> ClipList = new List<AudioClip>();
    private Dictionary<SFXType, AudioClip> SFXLib = new Dictionary<SFXType, AudioClip>();

    public GameObject SFXPrefab;

    void Start()
    {
        SFXManager = this;

        for (int i = 0; i < ClipName.Count; i++)
            SFXLib.Add(ClipName[i], ClipList[i]);
    }

    public void PlaySFX(SFXType Clip)
    {
        if (SFXLib.ContainsKey(Clip))
        {
            AudioSource SFX = Instantiate(SFXPrefab).GetComponent<AudioSource>();
            SFX.PlayOneShot(SFXLib[Clip]);
            Destroy(SFX.gameObject, SFXLib[Clip].length);
        }
    }
}
