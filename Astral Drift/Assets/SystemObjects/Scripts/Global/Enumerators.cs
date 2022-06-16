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

    public static Enumerators GetRandomEnumValue<Enumerators>()
    {
        Array A = Enum.GetValues(typeof(Enumerators));
        Enumerators V = (Enumerators)A.GetValue(Random.Range(0, A.Length));
        return V;
    }
}
