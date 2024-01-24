using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerData : MonoBehaviour


{
    public PlayerData(int v)
    {
        V = v;
    }

    public int V { get; }

    // Start is called before the first frame update
    void Start()
    {

        // Au démarrage du niveau, charger les données du joueur
        int niveauAtteint = SaveLoadManager.ChargerDonnees();

        // Utilisez la variable 'niveauAtteint' pour déterminer où commencer le joueur
        Debug.Log("Le joueur est au niveau : " + niveauAtteint);
    }
    private void Update()
    {
        


    }


}

