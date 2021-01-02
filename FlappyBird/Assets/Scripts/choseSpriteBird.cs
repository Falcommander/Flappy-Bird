using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choseSpriteBird : MonoBehaviour
{
    public List<RuntimeAnimatorController> list; // liste contenant tous les controleurs d'animation
    public List<Sprite> listSprite; // liste contenant tous les sprites de l'oiseau

    Animator anim;
    SpriteRenderer sprite;
    int listLength;
    bool startRainbow; // variable qui gère le moment où l'oiseau a le gold bonus
    int random;
    int rainbowBonus;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        listLength = list.Count;        
        rainbowBonus = 0;
        startRainbow = false;
        ChooseRandom();
    }

    void Update()
    {
        // Si le joueur a activé le bonus, alors tous les sprites de la liste se succèdent
        // pour donner un effet arc-en-ciel
        if (GameState.instance.IsBonusActivated())
        {
            if(!startRainbow)
                startRainbow = true;
            anim.runtimeAnimatorController = list[rainbowBonus];
            sprite.sprite = listSprite[rainbowBonus];            
            rainbowBonus = ++rainbowBonus % listLength;

        }
        // Condition qui permet de savoir quand l'animation arc-en-ciel est terminé
        // afin que l'oiseau récupère son sprite et son animation d'origine
        else if(startRainbow)
        {
            anim.runtimeAnimatorController = list[random];
            sprite.sprite = listSprite[random];
            startRainbow = false;
        }
    }

    /// <summary>
    /// Méthode qui choisit un nombre aléatoire parmi la liste de choix possibles, et l'affecte à l'oiseau
    /// </summary>
    void ChooseRandom()
    {
        random = Random.Range(0, listLength);
        switch (random)
        {
            case 0:
                anim.runtimeAnimatorController = list[0];
                sprite.sprite = listSprite[0];
                break;
            case 1:
                anim.runtimeAnimatorController = list[1];
                sprite.sprite = listSprite[1];

                break;
            case 2:
                anim.runtimeAnimatorController = list[2];
                sprite.sprite = listSprite[2];
                break;
        }
    }
}
