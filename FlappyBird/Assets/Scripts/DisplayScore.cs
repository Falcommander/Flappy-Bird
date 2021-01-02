using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    Text score;

    // L'affichage du score à la fin de la partie
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "SCORE \n" + GameState.instance.getScorePlayer().ToString();
        GameState.instance.SetScorePlayer(0);
    }

}
