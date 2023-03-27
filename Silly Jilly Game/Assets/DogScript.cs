using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;   
    public bool dogIsAlive = true;
    public PipeSpawnScript pipe;
    public static float timeScale;
    public GameObject pauseScreen;
    public bool Paused = false;
    public bool gameFinished;
   
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dogIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;            
        }
        if (Input.touchCount > 0 && dogIsAlive)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                myRigidBody.velocity = Vector2.up * flapStrength;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameFinished)
            {
                if (Paused == true)
                {
                    Time.timeScale = 0f;
                    dogIsAlive = false;
                    pauseScreen.SetActive(true);
                    Paused = false;           
                }
                else
                {
                    Time.timeScale = 1f;
                    dogIsAlive = true;
                    pauseScreen.SetActive(false);
                    Paused = true;
                }                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        dogIsAlive = false;
        gameFinished = true;
    }
}
