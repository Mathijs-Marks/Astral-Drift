using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //Important!

public class GameEvents : MonoBehaviour
{
    /*//Static Singleton reference to the script
    public static GameEvents instance { get; private set; }

    [SerializeField]
    private float _explodeSoundVolume = 1f, _playerDeathSoundVolume = 0.9f;

    public event Action onEnemyDeath;
    public event Action onWin;
    public event Action onLose, onPlayerDeath;
    public event Action<float, float> healthChange;
    public event Action onGameWin;

    void Awake()
    {
        instance = this;
    }

    // Gets invoked in: Enemy.cs
    public void EnemyDeath()
    {
        // Makes a call to: ScoreManager.cs & Screenshake.cs
        onEnemyDeath?.Invoke();

        // play the explosion soundclip
        Global.soundHandler.PlaySingleClip(Global.soundHandler.explode, _explodeSoundVolume);
    }

    // Gets invoked in: Statemanager.cs
    public void Win()
    {
        // Makes a call to: GameHandler.cs
        onWin?.Invoke();
    }

    // Gets invoked in: Statemanager.cs
    public void PlayerDeath()
    {
        
        // Makes a call to: ScreenShake.cs
        onPlayerDeath?.Invoke();

        // play the explosion + playerdeath sound
        Global.soundHandler.PlaySingleClip(Global.soundHandler.explode, _explodeSoundVolume);
        Global.soundHandler.PlaySingleClip(Global.soundHandler.playerDeath, _playerDeathSoundVolume);

        // Makes a call to: GameHandler.cs
        onLose?.Invoke();
    }

    // Gets invoked in: Player.cs
    public void OnHealthChange(float currentHealth, float maxHealth)
    {
        // Gets invoked in: HealthUI.cs
        healthChange?.Invoke(currentHealth, maxHealth);
    }*/
}
