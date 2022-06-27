using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {

        DontDestroyOnLoad(gameObject);

        //Set the global reference and destroy the current object if one already exists
        if(GlobalReferenceManager.AudioManagerRef == null)
            GlobalReferenceManager.AudioManagerRef = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //For each sound, set its corresponding values
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // PlaySound method with name as input
    public void PlaySound(string name)
    {
        //Find the correct sound in the array and play it
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Play();
    }
}
