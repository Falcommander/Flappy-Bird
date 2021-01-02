using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    // Start is called before the first frame update

    Text highscore;
    void Start()
    {
        highscore = GetComponent<Text>();
        highscore.text = "HIGHSCORE\n" + PlayerPrefs.GetInt(DifficultyManager.NameScore(), 0).ToString();
    }
}
