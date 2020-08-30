using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

  public Sound[] sounds;
  public static AudioManager instance;
  private Sound music;

  void Awake()
  {

    if (instance == null)
    {
      instance = this;
    }
    else
    {
      Destroy( gameObject );
      return;
    }

    DontDestroyOnLoad( gameObject );

    foreach (Sound s in sounds)
    {
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;

      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
      s.source.loop = s.loop;
    }
  }

  void Start()
  {
    Play("MUSIC");
    music = Array.Find(sounds, sound => sound.name == "MUSIC");
  }

  public void Play(string name)
  {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null)
    {
      Debug.LogWarning("Sound: " + name + " not found!");
      return;
    }
    s.source.Play();
    // if ( )
  }

  public void FightMusic( )
  {
    string name = "THEME1";
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null)
    {
      Debug.LogWarning("Sound: " + name + " not found!");
      return;
    }
    music.source.Stop();
    s.source.Play();
    music = s;
  }

  public void EndFight()
  {
    music.source.Stop();
    Play("MUSIC");
    music = Array.Find(sounds, sound => sound.name == "MUSIC");
  }

  public void PlayDelay(string name, float d)
  {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    if (s == null)
    {
      Debug.LogWarning("Sound: " + name + " not found!");
      return;
    }
    s.source.PlayDelayed( d );
  }


}
