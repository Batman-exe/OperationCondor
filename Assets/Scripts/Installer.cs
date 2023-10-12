using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private CardObserver cardObserver;
    private List<GameObject> cards = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i].GetComponentInChildren<Card>();
            cardObserver.Configure(card);
        }
    }

    public void AddCard(GameObject cardContainer)
    {
        cards.Add(cardContainer);
    }
}
