using UnityEngine;

public class HumanSpawner : MonoBehaviour
{

    [SerializeField] private int maxAmountHumans = 10;
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
        GameObject newPickupable = Instantiate(humanPickupable, Vector3.zero, Quaternion.identity);
        Vector3 newPos = randomisePosition(newPickupable.GetComponent<Collider2D>());
        newPickupable.transform.position = newPos;
    }

    public Vector2 randomisePosition(Collider2D collider)
    {
        //Set spawn position above visible playing area with random offset
        float positionOffset = Random.Range(1, GlobalReferenceManager.MainCamera.orthographicSize * 2);
        float withinScreenRange = (GlobalReferenceManager.ScreenCollider.sizeX / 2) - collider.bounds.size.x;
        Vector2 newPos = new Vector2(Random.Range(-withinScreenRange, withinScreenRange), GlobalReferenceManager.MainCamera.orthographicSize + GlobalReferenceManager.MainCamera.transform.position.y + positionOffset);
        return newPos;
    }
}
