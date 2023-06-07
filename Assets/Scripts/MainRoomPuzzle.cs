using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MainRoomPuzzle : MonoBehaviour
{
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public GameObject holder1;
    public GameObject holder2;
    public GameObject holder3;

    private int placedBoxCount;

    // Start is called before the first frame update
    void Start()
    {
        placedBoxCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (placedBoxCount == 3)
        {
            Debug.Log("All boxes placed correctly!");
            // Perform desired actions when all boxes are placed correctly
        }
    }

    public void CheckPlacement(GameObject box, GameObject holder)
    {
        if (box == box1 && holder == holder1)
        {
            placedBoxCount++;
            Debug.Log("Box 1 placed correctly on Holder 1");
            // Perform desired actions when Box 1 is placed correctly on Holder 1
        }
        else if (box == box2 && holder == holder2)
        {
            placedBoxCount++;
            Debug.Log("Box 2 placed correctly on Holder 2");
            // Perform desired actions when Box 2 is placed correctly on Holder 2
        }
        else if (box == box3 && holder == holder3)
        {
            placedBoxCount++;
            Debug.Log("Box 3 placed correctly on Holder 3");
            // Perform desired actions when Box 3 is placed correctly on Holder 3
        }
        else {
            Debug.Log("Not a correct placement");
        }
    }
}
