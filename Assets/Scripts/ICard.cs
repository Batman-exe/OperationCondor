using System;

public interface ICard 
{
    void Subscribe(Observer observer);
    void Unsubscribe(Observer observer);
    void Notify();

}
