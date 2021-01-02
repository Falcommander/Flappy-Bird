using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour, IBonus
{
    
    public GameObject bird;
    public int maxTime; //le temps que dure l'effet du bonus
    protected GameState instance;
    protected SoundManager sound;
    public virtual void EffectBonus()
    {
        throw new System.NotImplementedException();
    }

   

    // Start is called before the first frame update
    protected virtual void Start()
    {
        bird = FindObjectOfType<choseSpriteBird>().gameObject.transform.GetChild(0).gameObject;
        instance = GameState.instance;
        sound = SoundManager.instance;
    }

    public void EndBonus()
    {
        throw new System.NotImplementedException();
    }
}
