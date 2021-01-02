using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePipes : MonoBehaviour
{
    public Vector2 movement; // vitesse de mouvement
    public GameObject pipe1Up;
    public GameObject pipe1Down;

    public GameObject player;

    public Transform pipe1UpOriginalTransform;
    public Transform pipe1DownOriginalTransform;

    public SpriteRenderer sprite;

    protected float sizeX;
    public bool hasRestarted = false;
    public float separator;
    // Start is called before the first frame update
    void Start()
    {
        sizeX = sprite.size.x;
        separator = DifficultyManager.InitializeSeparator();
        positionPipes();
    }



    // Update is called once per frame
    protected void Update()
    {
        if (hasRestarted)
            hasRestarted = false;

        if (player != null)
        {
            if (!GameState.instance.HasStarted())
                movement.x = 0f;
            else
                movement.x = -2f;
        }

        pipe1Up.GetComponent<Rigidbody2D>().velocity = movement;
        pipe1Down.GetComponent<Rigidbody2D>().velocity = movement;

        //Lorsque les pipes sortent de l'écran, elles reviennent à leur position initiale
        if (pipe1Up.transform.position.x < Camera.main.ViewportToWorldPoint(Vector3.zero).x - (sizeX / 2))
            MoveToRightPipes();
    }

    /// <summary>
    /// Méthode qui s'occupe d'initialiser la position des pipes aléatoirement 
    /// </summary>
    public virtual void positionPipes()
    {
        float height = Random.Range(1, 4) - 2;
        float posY = pipe1UpOriginalTransform.position.y + height;
        Vector3 tmpPos = new Vector3(pipe1UpOriginalTransform.position.x, posY, pipe1Up.transform.position.z);
        pipe1Up.transform.position = tmpPos;

        posY = pipe1DownOriginalTransform.position.y + height;
        tmpPos = new Vector3(pipe1DownOriginalTransform.position.x, posY + separator, pipe1Down.transform.position.z);
        pipe1Down.transform.position = tmpPos;
    }

    /// <summary>
    /// Méthode qui renvoie les pipes à leur position d'origine une fois qu'elles sont sorties de l'écran
    /// </summary>
    public void MoveToRightPipes()
    {
        float height = Random.Range(1, 4) - 2;
        float posX = Camera.main.ViewportToWorldPoint(Vector3.right).x + (sizeX / 2);
        float posY = pipe1UpOriginalTransform.position.y + height;
        Vector3 tmpPos = new Vector3(posX, posY, pipe1Up.transform.position.z);
        pipe1Up.transform.position = tmpPos;

        posY = pipe1DownOriginalTransform.position.y + height;
        tmpPos = new Vector3(posX, posY, pipe1Down.transform.position.z);
        pipe1Down.transform.position = tmpPos;
        hasRestarted = true;
    }
}
