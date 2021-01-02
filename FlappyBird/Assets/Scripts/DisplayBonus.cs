using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBonus : MonoBehaviour
{
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Affiche le temps restant du bonus actif
        if (GameState.instance.IsBonusActivated())
        {
            int time = (int)GameState.instance.getTimeBonus() + 1;
            score.text = "BONUS TIME : \n" + time.ToString();
        }
        else
            score.text = "";
    }
}
