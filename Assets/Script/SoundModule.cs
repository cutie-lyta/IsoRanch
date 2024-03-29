using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component is made to manage audio on a GameObject.
/// </summary>
public class SoundModule : MonoBehaviour
{
    /// <summary>
    /// Dictionary containing an Audio associated to a string.
    /// </summary>
    [SerializeField]
    private SerializedDictionnary<string, Audio> _sounds;

    private AudioSource _source;
    private int _currentPriority;

    /// <summary>
    /// Definition of a sound.
    /// </summary>
    [Serializable]
    private struct Audio
    {
        public AudioClip Clip;

        [Range(0, 20)]
        public int Priority;

        [Range(0, 1.0f)]
        public float Volume;
    }

    /// <summary>
    /// Play a sound effect in the dictionary
    /// </summary>
    /// <param name="soundEffect"> The name of the sound effect. </param>
    /// <param name="priority"> An override to the default priority of the sound, if wanted. </param>
    public void Play(string soundEffect, int priority = -1)
    {
        if (priority == -1)
        {
            priority = _sounds[soundEffect].Priority;
        }

        if (!_source.isPlaying || priority >= _currentPriority)
        {
            _currentPriority = priority;
            _source.volume = _sounds[soundEffect].Volume;
            _source.clip = _sounds[soundEffect].Clip;
            _source.Play();
        }
    }

    private void Awake()
    {
        _source = gameObject.AddComponent<AudioSource>();
    }
}
