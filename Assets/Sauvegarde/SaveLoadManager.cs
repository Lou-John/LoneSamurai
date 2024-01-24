using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class SaveLoadManager
{
    public static void SauvegarderDonnees(int niveau)

    {
        PlayerDataBase data = new PlayerDataBase(1);
        data.niveauAtteint = niveau;

        BinaryFormatter formatter = new BinaryFormatter();
        string chemin = Application.persistentDataPath + "/donneesJoueur.dat";
        FileStream fichier = new FileStream(chemin, FileMode.Create);

        formatter.Serialize(fichier, data);
        fichier.Close();
    }

    public static int ChargerDonnees()
    {
        string chemin = Application.persistentDataPath + "/donneesJoueur.dat";

        if (File.Exists(chemin))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fichier = new FileStream(chemin, FileMode.Open);
            PlayerDataBase data = formatter.Deserialize(fichier) as PlayerDataBase;
            fichier.Close();

            return data.niveauAtteint;
        }
        else
        {
            // Si aucun fichier de sauvegarde n'est trouvé, retournez le niveau par défaut
            return 1;
        }
    }

}
