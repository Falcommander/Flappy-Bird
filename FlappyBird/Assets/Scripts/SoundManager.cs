using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource music; //AudioSource gérant les musiques du jeu
    public AudioSource sound; // AudioSource gérant les sons 
    public AudioClip buttonSound; // le son se lance lorsqu'il y a eu un clic sur un bouton
    public AudioClip bonusMusic; // le son se lance lorsque le gold bonus est activé
    public AudioClip intro; // le son principal se lançant à partir de l'introduction
    public AudioClip gameOver; // le son de l'écran de Game Over
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this);
    }

    private void Start()
    {
        ChangeClip(intro);        
    }

    /// <summary>
    /// Méthode qui change de clip
    /// </summary>
    /// <param name="audio">Le clip qui remplace l'actuel</param>
    public void ChangeClip(AudioClip audio)
    {
        music.clip = audio;
        PlayMusic();
    }

    public void PlayMusic()
    {
        music.Play();
    }

    public void PlaySound()
    {
        sound.Play();
    }
}
