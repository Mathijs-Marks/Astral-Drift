using UnityEngine;

public class FirerateUI : MonoBehaviour
{
    [SerializeField] private GameObject fullBar;
    [Tooltip("Edit this value to the current size of the sprite. (in canvas this is the width and height)")]
    [SerializeField] private float spriteSize = 172;

    private float blockSize = 34.5f; //This the the size of each block in pixels
    private float offset;

    //Moves the mask one block size sideways so it looks like a new block is added
    public void UpdateFirerateBar()
    {
        offset = -spriteSize + (blockSize * UI.instance.currentUpgrade);
        fullBar.transform.localPosition = new Vector3(offset, 0, 0);
    }
}
