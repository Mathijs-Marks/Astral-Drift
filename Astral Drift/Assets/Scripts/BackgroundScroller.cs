using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum scrollType
{
    BackgroundMovement, CameraMovement
}
public class BackgroundScroller : MonoBehaviour
{
    
    [SerializeField] private GameObject backgroundTile;
    [SerializeField] private Transform parent;
    [SerializeField] private Camera mainCam;
    Vector2 screenBounds;
    private GameObject currentTile;
    const int tileSize = 10;
    public bool cameraMovement;

    public Transform viewer;
    public Transform topSpawnLocation;

    public GameObject[] tileList;
    private List<GameObject> backgroundTileList = new List<GameObject>();

    private int generatedTiles = 0;
    private int scrolledTiles;

    private int lowestActiveTileInList;
    float lowerBound;
    float upperBound;

    public float moveSpeed = 1;
    public static Vector2 viewerPosition;
    // Start is called before the first frame update
    void Start()
    {
        scrolledTiles = tileList.Length-1;

        lowestActiveTileInList = 0;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        

        if (cameraMovement)
        {
            InstantiateTile();
            InstantiateTile();
            InstantiateTile();
        }
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
        viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
       
        UpdateVisibleTiles();
    }

    private void UpdateVisibleTiles()
    {
        /*if scrolltype == cameramovement
         * {
         * if(lowestTileInList.upperBorder < lowerBound)
         * {
         * find the lowest tile that is still active in the list (possibly by checking every active tile in the list?)
         * check which tile is the lowest
         * lowestTileInList.Setactive(false);
         * new lowest tile is the one above the previous tile
         * InstantiateTile() to instantiate a new tile at the proper height.
         * }
         * }
        */
        if (cameraMovement)
        {
            if(backgroundTileList[lowestActiveTileInList].transform.position.y +tileSize < viewer.transform.position.y + lowerBound)
            {
                backgroundTileList[lowestActiveTileInList].SetActive(false);
                lowestActiveTileInList++;
                InstantiateTile();
            }
                //(lowestActiveTileInList).
        }
        else
        {
            ScrollBackground();
        }
         /*if scrolltype == backgroundmovement
         * {
         * if(lowestTileInList.upperBorder < lowerBound)
         * {
         * RepositionTile();
         * }
         * }
         */
    }

    private void InstantiateTile()
    {
        GameObject tile = Instantiate(backgroundTile);
        float tileHeight = generatedTiles * tileSize;
        tile.transform.position = new Vector3(0,tileHeight*tile.transform.localScale.x,0);
        tile.transform.rotation = Quaternion.Euler(-90,0,0);
        tile.transform.parent = parent;
        backgroundTileList.Add(tile);
        generatedTiles++;
        Debug.Log("tile added");
    }

    private void ScrollBackground()
    {
        for(int i = 0; i<tileList.Length;i++)
        {
         currentTile = tileList[i];
            currentTile.transform.position = currentTile.transform.position - new Vector3(0,moveSpeed, 0);
            if(currentTile.transform.position.y + tileSize< lowerBound)
            {
                currentTile.transform.position = topSpawnLocation.position;
            }
        }
    }
}
