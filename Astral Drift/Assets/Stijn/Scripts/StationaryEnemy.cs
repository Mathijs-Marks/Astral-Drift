using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : AIMovementBehaviours
{

    [SerializeField] public float movementSpeed = 0.1f;
    [SerializeField] private bool isStationary;
    [SerializeField] public int maxHitpoints = 2;
    private int currentHitpoints;

    private Vector3 ownerLocation;
    private Vector3 startLocation;
    private bool hasBeenReset;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        startLocation = new Vector3(this.transform.position.x, screenBounds.y * 1.2f, this.transform.position.z);
        ownerLocation = startLocation;

        //Set start health
        currentHitpoints = maxHitpoints;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStationary)
        {
            MoveForward(movementSpeed);
        }
    }


    void MoveForward(float MovementSpeed)
    {
        if (transform.position.y <= -screenBounds.y * 1.2f && hasBeenReset == false)
        {
            //Reset enemy to top of the screen
            ownerLocation = startLocation;
            hasBeenReset = true;
        }
        else
        {
            //Move enemy downwards
            ownerLocation.y -= MovementSpeed * Time.fixedDeltaTime;
            transform.position = ownerLocation;

            if (hasBeenReset)
            {
                hasBeenReset = false;
            }
        }
    }

    //Enemy gets hit got hit
    public void GetHit(int damage)
    {
        currentHitpoints -= damage;

        if (currentHitpoints <= 0)
        {
            //TO DO: Enemy dies
            gameObject.SetActive(false);
        }
    }

}
