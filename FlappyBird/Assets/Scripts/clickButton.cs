using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class clickButton : MonoBehaviour
{
    public void onClick()
    {
        // La musique principale se lance lors du chargement de l'écran d'introduction

        if (SceneManager.GetActiveScene().name.Equals(ScenesManager.scene4))
        {
            ScenesManager.LoadScene1();
            SoundManager.instance.ChangeClip(SoundManager.instance.intro);
        }
        // La musique de Game Over se lance lors du chargement de l'écran de Game Over

        else if (SceneManager.GetActiveScene().name.Equals(ScenesManager.scene2))
            ScenesManager.LoadScene3();
        SoundManager.instance.PlaySound(); //le son du bouton est lancé
        
                
    }
}
