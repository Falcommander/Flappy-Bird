# README

## Ce qui a été intégré :

Un flappy bird fonctionnel qui a suivi les consignes du TP vu en cours et avec des fonctionnalités annexes.

Le jeu contient 4 scènes :

1. Initialisation : C'est la scène d'initialisation. Elle reste durant deux secondes puis charge la deuxième scène.

2. Menu : C'est la scène où le joueur choisit le niveau de difficulté de la partie. Il y a trois difficultés différentes : Facile, Moyen et Difficile. La différence de difficulté modifie la distance qui sépare les pipes supérieures et inférieures. Le score de la partie sera propre au niveau de difficulté choisi.

3. Game : La scène principale. La partie ne commence que lorsque le joueur appuie sur l'oiseau. Le skin de l'oiseau ainsi que celui du background sont choisis aléatoirement au chargement de la scène. 
Lorsque c'est fait, la partie débute. La rotation de l'oiseau est modifiée en fonction de sa vélocité. De plus, le joueur peut tomber sur un bonus (10% de chances réactualisé toutes les 2 secondes) symbolisé par une pièce dorée qui apparaitra entre deux pipes. Lorsque le joueur le prend, il devient invincible durant 6 secondes. Il peut alors traverser les pipes sans mourir durant ce laps de temps.
Lorsque le joueur touche une pipe ou le sol, alors il meurt et l'écran de Game Over se lance.

4. GameOver : La scène de fin. Elle affiche le highscore (selon le niveau de difficulté) ainsi que le score de la partie. Lorsque le joueur appuie sur le sprite "Tap in", il revient à la scène d'initialisation.

## Ce qui n'a pas été intégré :

1. D'autres bonus. Par exemple, un bonus qui permettrait à l'oiseau de ne plus sauter seulement lorsque le joueur appuie sur l'écran, mais suivre l'axe y du doigt du joueur.

Ce n'est pas présent par manque de temps. L'architecture du code est cependant pensé pour rendre son implémentation simple (ainsi que d'autres bonus).

2. Ajout de mécaniques dans le but de rendre le jeu moins répétitif : Par exemple, lorsque le joueur atteint 10 points, un boss apparaît (les pipes ne sont pas présentes durant ce laps de temps) et le joueur doit simplement éviter ces missiles. Chaque missile ésquivé rapporte un point. Puis les pipes reviennent. Etc.

Pareil, ce n'est pas présent par manque de temps.

3. Un code de meilleur qualité. Beaucoup de classes auraient pu être réunies dans une seule, l'architecture aurait pu être meilleure.

Manque de temps aussi.

## Difficultés rencontrées :

1. a. La séparation entre les pipes lors de l'implémentation de la difficulté. En mode hard, les pipes   (supérieure et inférieure) se rapprochaient passées les deux premières paires de pipes.
   b. Je m'en suis sorti en désactivant la collision entre l'oiseau et les pipes. Ainsi, j'ai pu remarquer que les pipes devenaient de plus en plus proches au fil de l'avancée d'une partie. Ca m'a permis de comprendre que le séparateur ne devait être inclus dans la position des pipes que lors du start, et pas lors de chaque appel dans l'update.

2. a. La rotation de l'oiseau. La rotation de l'oiseau faisait une rotation soudaine de 180°.
   b. Grâce à une vidéo d'une personne créant un flappy bird (source en bas du readme), j'ai utilisé d'autres méthodes modifiant la rotation (j'utilisais Quaternion.Angle quand cette personne utilise Quaternion.Euler).

3. a. Créer une physique semblable à celle du jeu original.
   b. La solution fut compliquée. Même en regardant une vidéo d'une personne faisant un Flappy Bird, en utilisant les mêmes valeurs que lui, la physique n'était absolument pas la même. J'ai dû modifier manuellement les paramètres du Rigidbody et de ma variable jump pour arriver à un résultat satisfaisant.


## Sources :
    -Musiques :
        Intro : Moog City - C418
        Game Over : Sweden - C418
        Bonus : Super Mario World - Invincible
                http://gamethemesongs.com/Super_Mario_World_-_Invincible.html
    -Sons :
        Bouton : touchButton du TP
    -Code :
        La plupart des classes : TP
        Rotation de l'oiseau : Develop and Publish Flappy Bird in 3 Hours With Unity3D - Renaissance Coders (1h25-1h26)
                               https://www.youtube.com/watch?v=A-GkNM8M5p8
        Physique de l'oiseau lorsqu'il saute : Make your own Flappy Bird in 10 minutes (Unity Tutorial) - Valem (3min12)
                                               https://www.youtube.com/watch?v=uRWmEjxY334
    -Sprites :
        Toutes : TP
