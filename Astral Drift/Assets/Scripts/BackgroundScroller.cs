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

    private GameObject currentTile;
    const int tileSize = 10;
    public bool cameraMovement;

    public Transform viewer;
    public Transform topSpawnLocation;

    public GameObject[] tileList;
    public GameObject[] backgroundTiles = new GameObject[3];

    private int generatedTiles = 0;
    private int scrolledTiles;

    private int lowestTileInList;
    float lowerBound;
    float upperBound;

    public float moveSpeed = 1;
    public static Vector2 viewerPosition;
    // Start is called before the first frame update
    void Start()
    {
        scrolledTiles = tileList.Length-1;
        float width = Screen.width;
        float height = Screen.height;

        lowerBound = mainCam.transform.position.y - height / 2;
        upperBound = mainCam.transform.position.y + height / 2;
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
            for(int i = 0;i< backgroundTiles.Length - 1; i++)
            {

            }
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
        generatedTiles++;
        tile.transform.position = generatedTiles * (tileSize * tile.transform.localScale);
        tile.transform.parent = parent;
        backgroundTiles[generatedTiles % 3] = tile;
    }

    private void ScrollBackground()
    {
        for(int i = 0; i<tileList.Length;i++)
        {
         currentTile = tileList[i];
            currentTile.transform.position = currentTile.transform.position - new Vector3(-moveSpeed, 0, 0);
            if(currentTile.transform.position.x< lowerBound)
            {
                currentTile.transform.position = topSpawnLocation.position;
            }
        }
    }
}
