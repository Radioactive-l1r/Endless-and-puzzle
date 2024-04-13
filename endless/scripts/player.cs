using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class player : MonoBehaviour
{
    public float speed;

    public int minX;
    public int maxX;
  
    public int Health;
    public Slider healthSlider;
    public GameObject gameOverpanel;
    public bool isPlayerAlive = true;
    public GameObject blasteffectObject;
    public float score = 0;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = Health;
        healthSlider.value = Health;
        StartCoroutine(IncreaseScoreCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        // setting up minX and maxX
        // clamping the player position to the camera’s view.
        Vector3 camPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -Mathf.RoundToInt(camPoint.x);
        maxX = Mathf.RoundToInt(camPoint.x);

        if (isPlayerAlive)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {

                transform.Translate(-speed, 0, 0);
                // Clamp the x position
                Vector3 clampedPosition = transform.position;
                clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
                transform.position = clampedPosition;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed, 0, 0);
                // Clamp the x position
                Vector3 clampedPosition = transform.position;
                clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
                transform.position = clampedPosition;

            }
        }

    }

  
    IEnumerator IncreaseScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            score++;
            Debug.Log("Score: " + score);
            if (score % 10 == 0 && score != 0)
            {

                scoreText.text = "Level "+score;
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="rock")
        {
            
            blastEffect(collision);
            gotHit();
        }
    }
    public void blastEffect(Collision2D collision)
    {
        Destroy(collision.gameObject);
        GameObject effect = Instantiate(blasteffectObject, collision.GetContact(0).point,Quaternion.identity);
        effect.GetComponent<Animator>().Play("blastAnim");
        Destroy(effect, 0.5f);
    }
    public void gotHit()
    {   
        Health--;
        healthSlider.value=Health;
        if(Health==0)
        {
            gameOverpanel.SetActive(true);
            isPlayerAlive = false;
            
        }
    }

    public void ReloadGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
