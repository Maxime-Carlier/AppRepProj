#################
### IMPORTANT ###
#################

Ce rendu est fait en binôme avec : Yasin Eroglu & Maxime Carlier - SI4 G2

Le document README.doc à la racine de ce sossier fait office de rapport et présente en plus de la question 2,
certain points important de notre projet. Une version PDF est a votre disposition également à la racine.

#####################################
### Comment lancer notre projet ? ###
#####################################

1- Dézipper le fichier carlier-eroglu.zip. Cela créera un dossier carlier-eroglu/

2- Lancer Visual Studio 2015.

3- Ouvrir la solution située dans carlier-eroglu/VelibApplication.sln

4- Une fois la solution lancée, Appuyer sur Start. Visual Studio téléchargera les dépendances NuGet nécessaire (Json et GMap.net)
   puis buildera les deux projet avant de lancer la solution.

#################################
### Comment Utiliser projet ? ###
#################################

ATTENTION : Ne saisissez pas des informations dans les champs Departure et Arrival trop rapidement sous peine
de rendre la saisie ultérieure "glitchy"

1- Une fois la solution démarée, une fenêtre s'affiche. Sur cette fenêtre quatre éléments important.
	a- au centre une carte
	b- a gauche en haut, un champs texte "Departure"
	c- a gauche en dessous de b), un champ de texte "Arrival"
	d- a gauche en dessous de c), un bouton Validate.

2- Saisir dans Departure une adresse corresponsant au point de départ voulus. Lors de la saisie, un champ apparait en dessous des boutons
   avec des suggestions fournie par le service Google Places. Séléctionner un des champs aura pour effet de remplir le champs en train d'être remplis

3- Saisir dans Arrival, une adresse correspondant au point d'arrivé désiré.

4- Valider les choix en appuyant sur le bouton Validate. L'application effectue le travail nécessaire et affiche sur la carte l'itinéraire a suivre
   avec en rouge la partie en vélo et en bleu, la partie a pied

