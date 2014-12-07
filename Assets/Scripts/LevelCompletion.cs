using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class LevelCompletion
{
    const string prefix = "LEVEL_COMPLETED_";
    const int completed = 1;
    const int notCompleted = 0;

    public static bool HasCurrentLevelBeenCompleted()
    {
        return HasLevelBeenCompleted(Application.loadedLevel);
    }

    public static bool HasLevelBeenCompleted(int level)
    {
        return PlayerPrefs.GetInt(GetKey(level), notCompleted) == completed;
    }

    public static void MarkCurrentLevelCompleted()
    {
        PlayerPrefs.SetInt(GetKey(Application.loadedLevel), completed);
    }

    private static string GetKey(int level)
    {
        return prefix + level;
    }
}

