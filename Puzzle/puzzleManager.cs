using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager : MonoBehaviour
{

    public Transform[] puzzles;
    public Transform currentPuzzle;
    public int IndexcurrentPuzzle=0;
    public int correctRot = 0;
    public bool won = false;
    public GameObject wonPanel;
    // Start is called before the first frame update
    void Start()
    {
        createNewPuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkWin()
    {
        bool allRotated = true;
        foreach (Transform part in currentPuzzle)
        {
            puzzlepart puzzlePart = part.GetComponent<puzzlepart>();
            if (!puzzlePart || !puzzlePart.myRotation)
            {
                allRotated = false;
                break; // No need to continue checking if one part is not rotated
            }
        }
        if (allRotated)
        {
            // Trigger win condition
            Debug.Log("You win!");
            won = true;
            wonPanel.SetActive(true);
        }
    }
    public void NextImage()
    {

        Destroy(currentPuzzle.gameObject);
        wonPanel.SetActive(false);

        IndexcurrentPuzzle++;
        createNewPuzzle();
        if (IndexcurrentPuzzle == puzzles.Length)
        {
            IndexcurrentPuzzle = 0;
        }
    }

    void createNewPuzzle()
    {
        currentPuzzle=Instantiate(puzzles[IndexcurrentPuzzle], transform.position, Quaternion.identity);
    }
}
