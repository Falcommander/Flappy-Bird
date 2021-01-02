using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideManagementBird : MonoBehaviour
{
    public List<Rigidbody2D> listColliders;
    GameState gs;

    void Start()
    {
        gs = GameState.instance;
    }


    // Update is called once per frame
    void Update()
    {
        foreach(Rigidbody2D collider in listColliders)
            if(GetComponent<endAction>().HasCollided())            
                collider.constraints = RigidbodyConstraints2D.FreezePosition;              
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PointBox"))
            gs.addScorePlayer(1);
    }
}
