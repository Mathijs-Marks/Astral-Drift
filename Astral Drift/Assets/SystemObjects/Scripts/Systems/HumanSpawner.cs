using UnityEngine;

public class HumanSpawner : MonoBehaviour
{

    [SerializeField] private int maxAmountHumans = 10; //Max amount of spawnable humans
    [HideInInspector] public int currentPickedUpHumans;
    [SerializeField] private GameObject humanPickupable;
    [SerializeField] private float maxSpawnTime, minSpawnTime;

    private float timer;
    private float spawnTime;


    private void Awake()
    {
        if (GlobalReferenceManager.HumanSpawnerRef == null)
            GlobalReferenceManager.HumanSpawnerRef = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime + 1);
    }
    private void FixedUpdate()
    {
        //This spawns a human in random set interval between minSpawnTime & maxSpawnTime
        timer += Time.deltaTime;
        if(timer > spawnTime && currentPickedUpHumans < maxAmountHumans)
        {
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime + 1);
            timer = 0;
            SpawnHuman();
        }
    }
    private void SpawnHuman()
    {
        //Spawn a new human pickupable at a random position
        GameObject newPickupable = Instantiate(humanPickupable, Vector3.zero, Quaternion.identity);
        Vector3 newPos = randomisePosition(newPickupable.GetComponent<Collider2D>());
        newPickupable.transform.position = newPos;
    }

    public Vector2 randomisePosition(Collider2D collider)
    {
        //Set spawn position above visible playing area with random offset within screen bounds
        float positionOffset = Random.Range(1, GlobalReferenceManager.MainCamera.orthographicSize * 2);
        float withinScreenRange = (GlobalReferenceManager.ScreenCollider.sizeX / 2) - collider.bounds.size.x;
        Vector2 newPos = new Vector2(Random.Range(-withinScreenRange, withinScreenRange), GlobalReferenceManager.MainCamera.orthographicSize + GlobalReferenceManager.MainCamera.transform.position.y + positionOffset);
        return newPos;
    }
}
