using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private CardObserver cardObserver;
    [SerializeField] private List<GameObject> cards;

    private void Awake()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i].GetComponentInChildren<Card>();
            cardObserver.Configure(card);
        }
    }
}
