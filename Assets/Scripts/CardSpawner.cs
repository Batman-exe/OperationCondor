using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private List<Vector3> spawnPositions;
    public Installer installer;

    private void Start()
    {
        installer = GameObject.FindObjectOfType<Installer>();
        ShuffleCards();
    }

    /// <summary>
    /// Changes the position of every card to any of the positions of spawnPositions.
    /// </summary>
    private void ShuffleCards()
    {
        List<Vector3> positions = new(spawnPositions);
        for (int i = 0; i < installer.cards.Count; i++)
        {
            int randPos = Random.Range(0, positions.Count);
            installer.cards[i].transform.position = positions[randPos];
            positions.RemoveAt(randPos);
        }
    }
}
