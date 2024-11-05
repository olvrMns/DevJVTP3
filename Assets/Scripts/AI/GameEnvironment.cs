using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameEnvironment
{

    private static GameEnvironment instance;

    private List<GameObject> checkpoints = new List<GameObject>();

    public List<GameObject> Checkpoints { get { return checkpoints; } }

    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {

                instance = new GameEnvironment();

                // Récupère tous les objets avec le tag "Checkpoint" et les ajoute à la liste checkpoints
                instance.Checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));

                // Trie la liste des checkpoints par nom pour garantir un ordre constant
                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList();
            }

            // Retourne l'instance unique de GameEnvironment
            return instance;
        }
    }
}