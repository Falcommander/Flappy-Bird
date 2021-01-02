using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endAction : MonoBehaviour
{
    private bool hasCollided = false;
    private bool gainPoint = false;
    GameState instance;
    SoundManager sound;

    private void Start()
    {
        instance = GameState.instance;
        sound = SoundManager.instance;
    }


    void OnCollisionEnter2D(Collision2D collision)
    { 
        //Gère le moment où l'oiseau entre en collision avec une pipe
        if(collision.gameObject.CompareTag("Pipes"))
        {
            instance.SetDead(true);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hasCollided = true;
        }
        //Gère la mort de l'oiseau en changeant de scène
        if(collision.gameObject.CompareTag("Floor"))
        {
            Death();     
        }
    }

    /// <summary>
    /// Méthode qui gère la mort du joueur
    /// </summary>
    public void Death()
    {
        if (!instance.IsDead())
            instance.SetDead(true);
        instance.CheckBonusDead(); //Check si le bonus était actif lorsque le joueur est mort
        instance.SaveScore();
        sound.ChangeClip(sound.gameOver);
        ScenesManager.LoadScene4();
    }

    public bool GainPoint()
    {
        return gainPoint;
    }

    public void SetGainPoint(bool gainPoint)
    {
        this.gainPoint = gainPoint;
    }
    public bool HasCollided()
    {
        return hasCollided;
    }
}
