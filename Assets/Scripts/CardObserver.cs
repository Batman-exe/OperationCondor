using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObserver : MonoBehaviour, Observer
{
    private Card firstTurned;
    private Card secondTurned;
    
    private bool cardTurning = false;

    public void Configure(ICard card)
    {
        card.Subscribe(this);
    }

    public void Updated(ICard card)
    {
        // Ther is not a card turning
        if(!cardTurning)
        {
            // There are no revealed cards
            if (firstTurned == null)
            {
                cardTurning = true;
                firstTurned = (Card)card;
                StartCoroutine(EnableSecondClick());
            }
            else if (secondTurned == null) // Just first card revealed
            {
                cardTurning = true;
                secondTurned = (Card)card;
                // Cards coincide
                if (firstTurned.country.Equals(secondTurned.country))
                    StartCoroutine(DestroyCards());
                // Cards are not from the same country
                else
                    StartCoroutine(ResetCards());
            }
        }
        else // A card has been clicked while another is turning
        {
            // sets the card to its original state
            Card otherCard = (Card)card;
            otherCard.Turn(); 
        }
    }

    IEnumerator DestroyCards()
    {
        yield return new WaitForSeconds(1.8f);
        firstTurned.gameObject.SetActive(false);
        secondTurned.gameObject.SetActive(false);
        firstTurned = null;
        secondTurned = null;
        cardTurning = false;
    }

    IEnumerator ResetCards()
    {
        yield return new WaitForSeconds(1.8f);
        firstTurned.Turn();
        secondTurned.Turn();
        firstTurned = null;
        secondTurned = null;
        yield return new WaitForSeconds(1.8f);
        cardTurning=false;
    }

    IEnumerator EnableSecondClick()
    {
        yield return new WaitForSeconds(1.8f);
        cardTurning = false;
    }
}
