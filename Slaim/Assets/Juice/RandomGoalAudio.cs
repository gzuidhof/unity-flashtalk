using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RandomGoalAudio : MonoBehaviour
{


    private AudioSource audioSource;

    [Serializable]
    public struct ClipProbability
    {
        public AudioClip clip;
        public float probability;
    }

    public ClipProbability[] clips;

    private static Dictionary<AudioClip, float> audioClips;

    void Start()
	{
        audioSource = GetComponent<AudioSource>();
        audioClips = new Dictionary<AudioClip, float>();
        foreach (var clip in clips)
        {
            audioClips.Add(clip.clip, clip.probability);
        }

        Game.instance.OnGoal += () => audioSource.PlayOneShot(SelectRandomClip());
	}


    private static AudioClip SelectRandomClip()
    {
        float choice = UnityEngine.Random.Range(0, audioClips.Values.Sum());
        foreach (var clip in audioClips)
        {
            choice -= clip.Value;
            if (choice <= 0f)
            {
                return clip.Key;
            }
        }
        Debug.Log(choice);
        return null;
    }
}
