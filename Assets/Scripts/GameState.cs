using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameState
{
    public static event DelegateNoParams OnLevelCompleted;
    public static event DelegateNoParams OnLevelFailed;
    public static event DelegateNoParams OnLevelOver;
    public static event DelegateNoParams OnAsteroidLaunched;

    public delegate void DelegateNoParams();

    public static void LevelCompleted()
    {
        OnLevelCompleted();
    }

    public static void LevelFailed()
    {
        OnLevelFailed();
    }

    public static void LaunchAsteroid()
    {
        OnAsteroidLaunched();
    }

    static GameState()
    {
        AddBasicListeners();
    }

    private static void AddBasicListeners()
    {
        // these local listeners ensure that at least one listener exists for every event (so there's no need to check for nulls)
        OnLevelOver += delegate() { };
        OnAsteroidLaunched += delegate() { };
        
        OnLevelCompleted += delegate() { OnLevelOver(); };
        OnLevelFailed += delegate() { OnLevelOver(); };
    }

    public static void ResetListeners()
    {
        OnLevelCompleted = null;
        OnLevelOver = null;
        OnAsteroidLaunched = null;
        OnLevelFailed = null;
        
        AddBasicListeners();
    }
}

