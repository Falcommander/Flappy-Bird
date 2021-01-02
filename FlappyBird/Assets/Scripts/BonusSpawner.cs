using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject bonus; //la prefab du bonus
    public Transform upPipe;
    public Transform downPipe;
    protected float timer; //la variable qui s'incrémente au fil du temps
    public float maxTime; //le temps avant qu'un nouveau nombre ne soig généré aléatoirement
    protected bool isInstantiate;
    protected int random;
    protected int pourcentage; //le pourcentage de chance qu'un bonus ne soit pas généré

    // Start is called before the first frame update
    protected void Start()
    {
        upPipe = GameObject.Find("Pipes").transform.GetChild(0).GetChild(0);
        downPipe = GameObject.Find("Pipes").transform.GetChild(0).GetChild(1);
        isInstantiate = false;
        timer = 0f;
    }
}
