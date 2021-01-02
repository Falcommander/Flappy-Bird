using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchAction : MonoBehaviour
{
    //PlayerPref
    public float jump;
    float angle;
    GameState gs;
    Rigidbody2D rb;
    Vector3 top;
    float smooth = 5f;
    // Start is called before the first frame update
    void Start()
    {
        gs = GameState.instance;
        gs.Starting(false);
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic= true;
        top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

    }

    void OnMouseDown()
    {
        if(!gs.HasStarted())
        {
            rb.isKinematic = false;
            gs.Starting(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        BirdMovement();
        BirdAngle();
    }

    /// <summary>
    /// Méthode qui s'occupe du déplacement de l'oiseau
    /// </summary>
    public void BirdMovement()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gs.isDead)
        {
            if (gs.HasStarted())
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                if (transform.position.y <= top.y)
                    rb.velocity = Vector2.up * jump;
                else
                    rb.velocity = new Vector2(0, -0.5f);
            }
               
        }
        
        if(gs.isDead)
            rb.velocity = Vector2.down * jump;

    }

    /// <summary>
    /// Méthode qui s'occupe de gérer l'angle de l'oiseau
    /// </summary>
    public void BirdAngle()
    {
        if(gs.HasStarted())
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), smooth * Time.deltaTime);
    }
}
