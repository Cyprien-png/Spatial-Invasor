# Projet C# Spatial-Invasor 

## Architecture

Nous voulions que la classe "MainGame" ne soit pas surchargée de code.
Afin d'y remédier, nous avons architecturé de manière à ce que MainGame ne contient le moins de code possible.
Pour cela, nous avons rendu nos autres classes indépendantes les unes des autres

Ainsi, MainGame ne contient que le code nécessaire et impossible à mettre autre part.

La classe "Playfield" s'occupe de l'affichage du terrain de jeu.

La classe "Entity" est la classe-mère de toute entitée sur le terrain, elle est nécessaire au fonctionnement des sous-classes "Creatures", "LaserShot" et "Wall".

La classe "Creatures" est donc une sous-classe dérivée de "Entity", ses principales fonctions sont : de limiter le mouvement afin d'éviter de sortir de la fenêtre ainsi que le système de tir, elle est nécessaire au fonctionnement des sous-classes "Player" et "Alien".

La classe "Alien" est dérivée de "Creatures", ses principales fonctions sont toutes liées au fonctionnement des trois classes représentant les principaux ennemis : "Crab", "Octopus" et "Squid".

La classe "UFO", bien que dérivée de Alien, n'utilise que la fonction de score de la classe.

## Spécificités

### Les composants
![](https://github.com/Cyprien-png/Spatial-Invasor/blob/main/Spatial-Invasor/Spatial-Invasor/Content/Example_Composant.PNG)

Comme précisé précédemment, afin d'éviter le surchargemment de code dans MainGame, nous avons opté pour l'utilisation de la classe "DrawableGameComponent" afin de réduire l'affichage d'un objet à une courte ligne de code et le rendre unique en cas de besoins. Une classe qui hérite de DrawableGameComponent est appelé un "composant" et elle possède ses propres fonctions "Update" et "Draw".

Il suffit donc simplement d'ajouter "Components.Add()" et de préciser dans les parenthèses la classe à afficher

### Les scènes
Une technique utilisée pour simuler un changement de fenêtre pendant l'exécution du programme. La liste "Components" offre la possibilité d'activer ou de désactiver certains composants. 

À la création de tous les composants du jeux, ceux-ci sont définis comme appartenant à une certaines "scène". C'est-à-dire une collection de composants spécifiques.
Par exemple : les componsants de la phase de jeux (Joueur, aliens, etc.) appartiennent à la scéne "Gameplay". Les composants du menu (Les options comme : Jouer, scores, quitter, etc.) appartienent eux à la scène "Menu".

Changer de scène signifie utiliser des composants ou non selon les besoins.
