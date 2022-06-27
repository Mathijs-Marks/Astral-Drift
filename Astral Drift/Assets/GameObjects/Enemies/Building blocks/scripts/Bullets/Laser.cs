using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] protected int damage;
    public int readDamage { get { return damage; } }
}
