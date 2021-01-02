using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyManager
{

    /// <summary>
    /// Methode permettant de connaître le nom de la difficulté choisie lorsqu'il faudra enregistrer le score
    /// </summary>
    /// <returns>le nom de la difficulté de la partie</returns>
    public static string NameScore()
    {
        switch(GameState.instance.difficulty)
        {
            case 0:
                return "HighScoreEasy";
            case 1:
                return "HighScoreMedium";
            case 2:
                return "HighScoreHard";
            default:
                return "";
        }
    }

    /// <summary>
    /// Sauvegarde le score de la partie
    /// </summary>
    /// <param name="scorePlayer">Le score de la partie</param>

    public static void SaveScore(int scorePlayer)
    {
        string difficulty = NameScore();
        if (scorePlayer > PlayerPrefs.GetInt(difficulty, 0))
            PlayerPrefs.SetInt(difficulty, scorePlayer);
    }

    /// <summary>
    /// Renvoie la distance entre deux pipes d'une même paire en fonction de la difficulté de la partie
    /// </summary>
    /// <returns>le séparateur</returns>

    public static float InitializeSeparator()
    {
        switch (GameState.instance.difficulty)
        {
            case 0:
                return 0.25f;                
            case 1:
                return 0.75f;                
            case 2:
                return 1.25f;
            default:
                return 0f;                
        }
    }
}
