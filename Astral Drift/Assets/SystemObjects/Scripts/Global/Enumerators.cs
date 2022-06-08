using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enumerators : MonoBehaviour
{
    Enumerators instance;
    public enum EnemyFormationTypes
    {
        HorizontalLine, VerticalLine, RightDiagonal, LeftDiagonal, VFormation
    }

    public enum EnemyTypes
    {
        nonShooting = 2, stationary = 3, rotating = 5, shotgun = 6, laser = 7, waveShot = 8, gatling = 9, homing = 10, bloom = 14, superBloom = 16
    }

    public static Enumerators GetRandomEnumValue<Enumerators>()
    {
        Array A = Enum.GetValues(typeof(Enumerators));
        Enumerators V = (Enumerators)A.GetValue(Random.Range(0, A.Length));
        return V;
    }
}
