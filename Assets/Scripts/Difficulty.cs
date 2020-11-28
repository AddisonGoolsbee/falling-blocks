using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float timeToMaxDifficulty = 60;

    public static float getDifficulty()
    {
        return Mathf.Clamp01(Time.time / timeToMaxDifficulty);
    }


}

