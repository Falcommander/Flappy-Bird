using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    int scorePlayer;
    float timeBonus;
    // Start is called before the first frame update
    public static GameState instance;
    bool gameStarted = false; //vérifie si le jeu a débuté (çad lorsque le joueur a cliqué sur l'oiseau)
    bool bonusActivated = false; //vérifie si un bonus a été activé
    public int difficulty; //difficulté du jeu (0 = facile, 1 = moyen, 2 = difficile)
    int spriteBK; //le chiffre correspondant au background (0 = jour, 1 = nuit)
    public bool isDead; //booléen vérifiant l'état (mort ou vivant) de l'oiseau

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
    void Start()
    {
        scorePlayer = 0;
        timeBonus = 0;
        spriteBK = 0;
        isDead = false;
        bonusActivated = false;
    }

   /// <summary>
   /// Fonction empêchant le bonus de continuer lors du démarrage d'une nouvelle partie si le joueur avait le bonus d'actif
   /// </summary>
    public void CheckBonusDead()
    {
        if (isDead && bonusActivated)
            bonusActivated = false;
    }

    /// <summary>
    /// Fonction enregistrant le score
    /// </summary>
    public void SaveScore()
    {
        DifficultyManager.SaveScore(scorePlayer);
        isDead = false;
    }

    public void addScorePlayer(int toAdd)
    {
        scorePlayer += toAdd;
    }

    public int getScorePlayer()
    {
        return scorePlayer;
    }

    public void addTime(float toAdd)
    {
        timeBonus -= toAdd;
    }

    public void setTime(float toAdd)
    {
        timeBonus = toAdd;
    }

    public float getTimeBonus()
    {
        return timeBonus;
    }

    public void Starting(bool hasStarted)
    {
        gameStarted = hasStarted;
    }

    public void SetScorePlayer(int score)
    {
        this.scorePlayer = score;
    }

    public bool HasStarted()
    {
        return gameStarted;
    }

    public bool IsBonusActivated()
    {
        return bonusActivated;
    }

    public void SetBonusActivated(bool stateBonus)
    {
        bonusActivated = stateBonus;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetDead(bool dead)
    {
        isDead = dead;
    }

    public void setBk(int bk)
    {
        spriteBK = bk;
    }

    public int getSpriteBk()
    {
        return spriteBK;
    }
}
