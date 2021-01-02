using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBk : MonoBehaviour
{
    float sizeX; // taille du sprite
    public Transform positionRestart; // position initiale 
    public float movement; // vitesse de mouvement
    // Start is called before the first frame update
    void Start()
    {
        sizeX = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {

        if(sizeX == 0)
            sizeX = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        GetComponent<Rigidbody2D>().velocity = new Vector2(movement, 0);
        // Lorsque le background quitte l'écran, il revient à sa position initiale
        if (transform.position.x < Camera.main.ViewportToWorldPoint(Vector3.zero).x - (sizeX / 2))                     
            transform.position = new Vector3(positionRestart.position.x + sizeX - 0.1f,transform.position.y,transform.position.z);
        
    }
}
