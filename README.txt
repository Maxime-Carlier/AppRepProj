#################
### IMPORTANT ###
#################

Ce rendu est fait en bin�me avec : Yasin Eroglu & Maxime Carlier - SI4 G2

Le document README.doc � la racine de ce sossier fait office de rapport et pr�sente en plus de la question 2,
certain points important de notre projet. Une version PDF est a votre disposition �galement � la racine.

#####################################
### Comment lancer notre projet ? ###
#####################################

1- D�zipper le fichier carlier-eroglu.zip. Cela cr�era un dossier carlier-eroglu/

2- Lancer Visual Studio 2015.

3- Ouvrir la solution situ�e dans carlier-eroglu/VelibApplication.sln

4- Une fois la solution lanc�e, Appuyer sur Start. Visual Studio t�l�chargera les d�pendances NuGet n�cessaire (Json et GMap.net)
   puis buildera les deux projet avant de lancer la solution.

#################################
### Comment Utiliser projet ? ###
#################################

ATTENTION : Ne saisissez pas des informations dans les champs Departure et Arrival trop rapidement sous peine
de rendre la saisie ult�rieure "glitchy"

1- Une fois la solution d�mar�e, une fen�tre s'affiche. Sur cette fen�tre quatre �l�ments important.
	a- au centre une carte
	b- a gauche en haut, un champs texte "Departure"
	c- a gauche en dessous de b), un champ de texte "Arrival"
	d- a gauche en dessous de c), un bouton Validate.

2- Saisir dans Departure une adresse corresponsant au point de d�part voulus. Lors de la saisie, un champ apparait en dessous des boutons
   avec des suggestions fournie par le service Google Places. S�l�ctionner un des champs aura pour effet de remplir le champs en train d'�tre remplis

3- Saisir dans Arrival, une adresse correspondant au point d'arriv� d�sir�.

4- Valider les choix en appuyant sur le bouton Validate. L'application effectue le travail n�cessaire et affiche sur la carte l'itin�raire a suivre
   avec en rouge la partie en v�lo et en bleu, la partie a pied

