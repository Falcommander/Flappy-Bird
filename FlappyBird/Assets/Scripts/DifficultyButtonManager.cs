using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButtonManager : MonoBehaviour
{
    Button btn; // le bouton correspondant à la difficulté choisie

    public void OnClick()
    {
        btn = GetComponent<Button>();
        switch (btn.name)
        {
            case ("easy"):
                GameState.instance.difficulty = 0;
                break;
            case ("medium"):
                GameState.instance.difficulty = 1;
                break;
            case ("hard"):
                GameState.instance.difficulty = 2;
                break;
        }
        SoundManager.instance.PlaySound();
        ScenesManager.LoadScene3();
    }
}
