using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
 /*   public enum States {WIN, LOSE, PAUSE, PLAY, START};

    public States currentState;

    private void Awake()
    {
        // set the state to play when you start the game
        SetState(States.PLAY);
    }

    // Start is called before the first frame update
    void Start()
    {
        Global.stateManager = this;
    }

    public void SetState(States newState)
    {
        // change current state only when it changes
        if (currentState != newState)
        {
            currentState = newState;
            ChangeGameState();
        }
    }

    private void ChangeGameState()
    {
        // run correct functions for each state
        switch (currentState)
        {
            case States.WIN:
                Global.gameTime.change(LevelDescription.winSlowdownSpeed);
                GameEvents.instance.Win();
                break;
            case States.LOSE:
                Global.gameTime.change(LevelDescription.deathSlowdownSpeed);
                GameEvents.instance.PlayerDeath();
                break;
            case States.PAUSE:
                Global.gameTime.change(0f);
                break;
            case States.PLAY:
                Global.gameTime.change(1f);
                break;
            default:
                break;
        }
    }*/
}
