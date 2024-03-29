using System;
using UnityEngine;

public class SoundModule : MonoBehaviour
{
    [Serializable]
    private struct Audio
    {
        public AudioClip Clip;

        [Range(0, 20)]
        public int Priority;

        [Range(0, 1.0f)]
        public float Volume;
    }

    [SerializeField]
    private SerializedDictionnary<string, Audio> _sounds;

    private AudioSource _source;
    private int _currentPriority;

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
