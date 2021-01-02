using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBonusSpawner : BonusSpawner
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        random = Random.Range(0, 100);
        pourcentage = 90; //90% de chances que le bonus n'apparaisse pas
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(GameState.instance.HasStarted())
        {
            if (random >= pourcentage) 
            {
                //Le bonus n'apparait que si le tuyau vient de respawn
                if (upPipe.GetComponentInParent<movePipes>().hasRestarted) 
                    if (!isInstantiate)
                        InstantiateBonus();
            }
            else
            {
                // Au bout de deux secondes, un nouveau nombre aléatoire est généré
                if (timer % 60 >= 2)
                {
                    random = Random.Range(0, 100);
                    timer = 0f;
                }
            }
            //Un nouveau nombre aléatoire est génété 10 secondes après qu'il soit apparu
            if (timer % 60 >= maxTime)
            {
                random = Random.Range(0, 100);
                isInstantiate = false;
            }
        }        
    }

    /// <summary>
    /// Fonction qui génère le bonus dans le jeu
    /// </summary>
    public void InstantiateBonus()
    {
        GameObject newBonus = Instantiate(bonus);
        newBonus.transform.position = new Vector3(upPipe.position.x, (upPipe.position.y + downPipe.position.y) / 2, upPipe.position.z);
        timer = 0f;
        isInstantiate = true;
    }
}
