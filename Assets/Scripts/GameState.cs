using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameState
{
    public static event DelegateNoParams OnLevelCompleted;
    public static event DelegateNoParams OnLevelOver;

    public delegate void DelegateNoParams();

    public static void LevelCompleted()
    {
        OnLevelCompleted();
    }

    static GameState()
    {
        AddBasicListeners();
    }

    private static void AddBasicListeners()
    {
        // these local listeners ensure that at least one listener exists for every event (so there's no need to check for nulls)
        OnLevelOver += delegate() { };
        
        // current level always ends the level when player dies or timer runs out. maybe later on there will be different levels..
        OnLevelCompleted += delegate() { OnLevelOver(); };
    }

    public static void ResetListeners()
    {
        OnLevelCompleted = null;
        OnLevelOver = null;
        
        AddBasicListeners();
    }
}

