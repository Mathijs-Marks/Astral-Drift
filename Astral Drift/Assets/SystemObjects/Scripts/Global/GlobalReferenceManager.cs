using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalReferenceManager
{
    public static Player PlayerScript; // Reference to Player script.
    public static PlayerHealth PlayerHealthScript; // Reference to the Player health.
    public static Transform PlayerPosition; // Reference to Player position.
    public static GameOverHandler GameOverMenu; // Reference to game-over script.
    public static PauseMenu PauseMenu; // Reference to Pause menu script.
    public static UI UIMenu; // Reference to UI script.
    public static Camera MainCamera; //Reference to main Camera
    public static SetColliderSize ScreenCollider;
    public static BackgroundScroller background; //Reference to background
    public static AudioManager AudioManagerRef;
    public static HumanSpawner HumanSpawnerRef;
}
