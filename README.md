# Gestion de frais

Application de gestion de frais réalisée dans le cadre ma période de professionnalisation de 1ère année de BTS.

![Game](http://image.noelshack.com/fichiers/2020/26/7/1593354223-saisir.png
)

Le repo contient un dump de la base de donnée SQL, les classes métiers qui correspondent et une classes DAO contenant les requêtes SQL.
Les formulaires ne sont pas disponibles.

## Installation

Créez une base de donnée et exécutez le code SQL dans une commande MySQL.


## Utilisation

La classe DAOFrais permet d'exécuter les requêtes sur la base de données. Toutes les méthodes sont en static et peuvent être utilisées de la manière suivante :

```python
Visiteur visiteur = DAOFrais.GetVisiteurByEmail();
```

