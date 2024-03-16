using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
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
    private static bool _isCompassVisible;
    public static bool isCompassVisible
    {
        get => _isCompassVisible;
        set
        {
            if (value != _isCompassVisible)
            {
                _isCompassVisible = value;
                NotifySubscribers(nameof(isCompassVisible));
            }
        }
    }

    private static bool _isRadarVisible;
    public static bool isRadarVisible
    {
        get => _isRadarVisible;
        set
        {
            if (value != _isRadarVisible)
            {
                _isRadarVisible = value;
                NotifySubscribers(nameof(isRadarVisible));
            }
        }
    }

    public static List<Action<String>> Subscribers { get; } = new();
    public static void Subscribe(Action<String> action) =>
        Subscribers.Add(action);
    public static void Unsubscribe(Action<String> action) =>
        Subscribers.Add(action);
    private static void NotifySubscribers(String propName) =>
        Subscribers.ForEach(action => action(propName));
}