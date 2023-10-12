using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Card : MonoBehaviour, ICard
{
    public enum Country
    {
        Argentina,
        Chile,
        Uruguay,
        Paraguay
    }

    private readonly List<Observer> observers = new List<Observer>();

    public bool revealed;
    private Animator animator;
    public Country country; 

    private void Awake()
    {
        revealed = false;
        animator = GetComponent<Animator>();
    }

    public void Subscribe(Observer observer)
    {
        observers.Add(observer);
        // observer.Updated(this);
    } 

    public void Unsubscribe(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        for (int i =0; i<observers.Count; i++)
            observers[i].Updated(this);
    }

    /// <summary>
    /// Turns the card.
    /// </summary>
    public void Turn()
    {
        revealed = !revealed;
        animator.SetBool("Revealed", revealed);
    }

    /// <summary>
    /// When card is clicked reveals the card and notifies the observers.
    /// </summary>
    private void OnMouseDown()
    {
        if(!revealed)
        {
            Turn();
            Notify();
        }
    }
}
