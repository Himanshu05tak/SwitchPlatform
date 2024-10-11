using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Endless
{
    public static class Difficulty_Level
    {
        [SerializeField]
        public static float secondsToDifficult = 60f;

        public static float GetDifficultPercent()
        {
            return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToDifficult);
        }
    }
}

