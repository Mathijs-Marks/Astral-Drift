using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// On death, an explosion animation is played.
/// </summary>
public class ExplosionAnimation : MonoBehaviour
{
    
    private void Start()
    {
        // Destroy the game object after the animation has run its course.
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
    
}
