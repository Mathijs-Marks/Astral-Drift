using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Any object that needs to be accessed globally is documented here.
/// Note that all references are static, as we only want 1 instance of that reference.
/// </summary>
public static class GlobalReferenceManager
{
    public static Player PlayerScript; // Reference to Player script.
    public static PlayerHealth PlayerHealthScript; // Reference to the Player health.
    public static Transform PlayerPosition; // Reference to Player position.
    public static GameOverHandler GameOverMenu; // Reference to game-over script.
    public static StateHandler StateHandler; // Reference to Pause menu script.
    public static UI UIMenu; // Reference to UI script.
    public static Camera MainCamera; //Reference to main Camera
    public static SetColliderSize ScreenCollider; // Reference to the screen boundary collider
    public static BasicCameraScript cameraScript; // Reference to the attached camera script
    public static AudioManager AudioManagerRef; // Reference to the audio manager
    public static HumanSpawner HumanSpawnerRef; // Reference to the human pickup
    public static EndlessTerrain EndlessBackground; // Reference to the procedurally generated background
}
