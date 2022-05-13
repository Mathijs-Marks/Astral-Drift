using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector3 location;
    private Vector2 screenBounds;
    [HideInInspector]
    public float speedMultiplier = 1;
    [HideInInspector]
    public GameObject creator;
    private GunBarrel barrelRef;


    // Start is called before the first frame update
    void Start()
    {
        barrelRef = creator.GetComponent<GunBarrel>();
        location = this.transform.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShootProjectile();
    }

    void ShootProjectile()
    {
        if (barrelRef != null)
        { 
            location.y -= speedMultiplier * Time.fixedDeltaTime;
            this.transform.position = location;
        }

        if( transform.position.y < -screenBounds.y * 1.2f)
        {
            Destroy(this.gameObject);
        }
    }
}
