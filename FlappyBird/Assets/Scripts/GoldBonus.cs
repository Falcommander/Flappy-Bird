using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBonus : Bonus
{
    public Transform box1;
    public Transform box2;
    public Transform upPipe;
    public Transform downPipe;
    List<Transform> pipes; // liste qui contient toutes les pipes de la scène


    // Start is called before the first frame update
    protected new virtual void Start()
    {
        base.Start();
        box1 = GameObject.Find("Pipes").transform.GetChild(2);
        box2 = GameObject.Find("Pipes").transform.GetChild(3);
        upPipe = GameObject.Find("Pipes").transform.GetChild(0).GetChild(0);
        downPipe = GameObject.Find("Pipes").transform.GetChild(0).GetChild(1);
        pipes = new List<Transform>
        {
            upPipe,
            downPipe
        };

        upPipe = GameObject.Find("Pipes").transform.GetChild(1).GetChild(0);
        downPipe = GameObject.Find("Pipes").transform.GetChild(1).GetChild(1);
        pipes.Add(upPipe);
        pipes.Add(downPipe);
        maxTime = 6;
        GameState.instance.setTime(maxTime);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //la position du bonus doit rester entre les deux pipes de la paire
        transform.position = new Vector3(pipes[0].position.x, (pipes[0].position.y + pipes[1].position.y) / 2, pipes[0].position.z);
        //Gère le cas où l'effet du bonus est en cours
        if (instance.IsBonusActivated())
        {
            instance.addTime(Time.deltaTime);
            if (instance.getTimeBonus()%60 <= 0)
            {
                EndBonus();
                Destroy(gameObject);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            EffectBonus();
        }
    }

    /// <summary>
    /// Méthode qui s'occupe de l'effet du bonus
    /// </summary>
    public new void EffectBonus()
    {
        //toutes les pipes n'ont plus de collider et leur transparence est diminuée
        foreach(Transform pipe in pipes)
        {
            pipe.GetComponent<BoxCollider2D>().enabled = false;
            Color color = pipe.GetComponent<SpriteRenderer>().color;
            color.a = 0.4f;
            pipe.GetComponent<SpriteRenderer>().color = color;

        }

        GetComponent<BoxCollider2D>().enabled = false;
        //Les box de score augmentent en taille pour faire toute la hauteur de l'écran
        box1.localScale += new Vector3(0, 40, 0);
        box2.localScale += new Vector3(0, 40, 0);
        instance.SetBonusActivated(true);
        sound.ChangeClip(sound.bonusMusic); // activation de la musique du bonus
    }

    /// <summary>
    /// Méthode qui gère le bonus une fois terminé
    /// </summary>
    public new void EndBonus()
    {
        //toutes les pipes ont leur collision de retour, et leur opacité revient à la normale
        foreach (Transform pipe in pipes)
        {
            pipe.GetComponent<BoxCollider2D>().enabled = true;
            Color color = pipe.GetComponent<SpriteRenderer>().color;
            color.a = 1f;
            pipe.GetComponent<SpriteRenderer>().color = color;
        }
        //les box de score retrouvent leur taille originale
        box1.localScale -= new Vector3(0, 40, 0);
        box2.localScale -= new Vector3(0, 40, 0);
        instance.setTime(0);
        instance.SetBonusActivated(false);
        sound.ChangeClip(sound.intro);
    }
}
