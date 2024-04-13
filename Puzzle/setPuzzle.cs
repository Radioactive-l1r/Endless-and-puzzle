using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setPuzzle : MonoBehaviour
{

    public GameObject Prefab_PuzzlePart;
    int row = 3;
    int col = 3;
    // add here all puzzle images
    public Sprite[] puzzleImages=new Sprite[9];
    // Start is called before the first frame update
    void Start()
    {
        GeneratePuzzle();
    }
    void GeneratePuzzle()
    {
        int current_image = 0;
        // Calculate the spacing between each puzzle part
        Vector3 spacing = new Vector3(1f, -1f, 0f); // Adjust as needed

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                // Calculate position based on row and col
                Vector3 position = new Vector3(j * spacing.x - 1, i * spacing.y+1, 0f);
                // Randomly select rotation
                int randomRotation = Random.Range(0, 3) * 90;
                // Instantiate the puzzle part at the calculated position
                GameObject newPart = Instantiate(Prefab_PuzzlePart, position, Quaternion.Euler(0, 0, randomRotation));

                newPart.transform.parent = transform;
                
                newPart.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = puzzleImages[current_image];
                current_image++;


            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
