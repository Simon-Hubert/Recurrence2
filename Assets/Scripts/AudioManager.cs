using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] _sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in _sounds)
        {
            s._source = gameObject.AddComponent<AudioSource>();
            s._source.clip = s._clip;

            s._source.volume = s._volume;
            s._source.pitch = s._pitch;
            s._source.loop = s._loop;
        }
    }

    private void Start()
    {
        PlaySound("Theme");
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound._name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found !");
            return;
        }
        s._source.Play();
    }

    public void PlayRand()
    {
        int rand = UnityEngine.Random.Range(0,3);
        Sound s = _sounds[rand];
        s._source.Play();
    }
}
