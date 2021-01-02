using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreUpdate : MonoBehaviour
{
    Text score;

    // L'affichage du score au cours de la partie
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = GameState.instance.getScorePlayer().ToString();
    }
}
