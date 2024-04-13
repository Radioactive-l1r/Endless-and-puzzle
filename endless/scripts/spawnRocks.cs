using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRocks : MonoBehaviour
{

    public GameObject rockPrefab;
    public int minX;
    public int maxX;
    public player player;
    public float waitTimer=1f;

    // Start is called before the first frame update
    void Start()
    {
        // setting up minX and maxX
        Vector3 camPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -Mathf.RoundToInt(camPoint.x);
        maxX = Mathf.RoundToInt(camPoint.x);

        StartCoroutine(spawnRock());

    }

    IEnumerator spawnRock()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTimer);


            player = GameObject.Find("Player").GetComponent<player>();
            if (player.score > 20)
            {
                waitTimer = 0.5f;
            }

            int xPos = Random.Range(minX, maxX);
            Vector3 newSpawnPoint = new Vector3(xPos, 7, 0);
            Instantiate(rockPrefab, newSpawnPoint, Quaternion.identity);

        }
    }
}
