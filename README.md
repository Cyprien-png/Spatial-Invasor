# Spatial-Invasor
## Projet C#

### Architecture

Nous voulions que la classe "MainGame" ne soit pas surchargée de code.
Afin d'y remédier, nous avons architecturé de manière à ce que MainGame ne contient le moins de code possible.
Pour cela, nous avons rendu nos autres classes indépendantes les unes des autres

Ainsi, MainGame ne contient que le code nécessaire et impossible à mettre autre part.

La classe "Playfield" s'occupe de l'affichage du terrain de jeu.

La classe "Entity" est la classe-mère de toute entitée sur le terrain, elle est nécessaire au fonctionnement des sous-classes "Creatures", "LaserShot" et "Wall".

La classe "Creatures" est donc une sous-classe dérivée de "Entity", ses principales fonctions sont : de limiter le mouvement afin d'éviter de sortir de la fenêtre ainsi que le système de tir, elle est nécessaire au fonctionnement des sous-classes "Player" et "Alien".

La classe "Alien" est dérivée de "Creatures", ses principales fonctions sont toutes liées au fonctionnement des trois classes représentant les principaux ennemis : "Crab", "Octopus" et "Squid".

La classe "UFO", bien que dérivée de Alien, n'utilise que la fonction de score de la classe.

### Spécificités

