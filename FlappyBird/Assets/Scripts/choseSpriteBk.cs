using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choseSpriteBk : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> bk; // liste contenant tous les sprites du background

    int random;
    void Start()
    {
        // Au début de l'écran du jeu, un nombre aléatoire est choisi
        if (SceneManager.GetActiveScene().name.Equals(ScenesManager.scene3))
        {
            random = Random.Range(0, 2);
            GameState.instance.setBk(random);

            foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                if (random == 0)
                    sr.sprite = bk[0];
                else
                    sr.sprite = bk[1];
            }
        }
        // Au début de l'écran de Game Over, le même background est affecté
        else
            foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sr.sprite = bk[GameState.instance.getSpriteBk()];
            }
    }
}
