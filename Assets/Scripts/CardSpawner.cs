using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> cards;
    [SerializeField] private List<Vector3> spawnPositions;

    private void Awake()
    {
        Installer installer = GameObject.FindObjectOfType<Installer>();
        foreach (var card in cards)
        {
            installer.AddCard(Instantiate(card));
        }

        ShuffleCards();
    }

    /// <summary>
    /// Changes the position of every card to any of the positions of spawnPositions.
    /// </summary>
    private void ShuffleCards()
    {
        List<Vector3> positions = new(spawnPositions);
        for (int i = 0; i < cards.Count; i++)
        {
            int randPos = Random.Range(0, positions.Count);
            cards[i].transform.position = positions[randPos];
            positions.RemoveAt(randPos);
        }
    }
}
