using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static float _characterStamina;
    public static float CharacterStamina
    {
        get => _characterStamina;
        set
        {
            if (_characterStamina != value)
            {
                _characterStamina = value;
                NotifySubscribers(nameof(CharacterStamina));
            }
        }
    }


    public static List<Action<String>> Subscribers { get; set; } = new();

    public static void Subscribe(Action<String> action) =>
        Subscribers.Add(action);

    public static void Unsubscribe(Action<String> action) =>
        Subscribers.Remove(action);

    public static void NotifySubscribers(String propName) =>
        Subscribers.ForEach(action =>  action(propName));
    
}