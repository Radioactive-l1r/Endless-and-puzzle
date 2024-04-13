using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlepart : MonoBehaviour
{
    private int[] rotations = { 0, 90, 180, 260 };
    private int currentIndex = 0;

    public puzzleManager puzzleManager;
    public bool myRotation = false;
    private void Start()
    {

        puzzleManager = GameObject.Find("puzzleManager").GetComponent<puzzleManager>();

        if (transform.rotation.z == 0 || transform.rotation.z == 360)
        {
            Debug.Log("Placed properly");
            myRotation = true;
        }
        else
        {
            myRotation = false;
        }
    }
    void OnMouseDown()
    {
        // Increment the current index, or reset it if it exceeds the array length
        currentIndex = (currentIndex + 1) % rotations.Length;

        // Set the rotation of the object
        transform.rotation = Quaternion.Euler(0, 0, rotations[currentIndex]);
        if(transform.rotation.z==0 )
        {
            myRotation = true;
            puzzleManager.checkWin();

            Debug.Log("Placed properly");
        }
        else
        {
            myRotation = false;
        }
    }
}
