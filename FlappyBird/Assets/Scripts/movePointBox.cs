using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePointBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pipe;
    public SpriteRenderer sprite;
    float sizeY;
    void Start()
    {
        sizeY = sprite.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pipe.position - new Vector3(0, 2*sizeY, 0);
    }
}
