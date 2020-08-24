using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject moleContainer;

    public float spawnDuration = 1.5f;
    public float spawnDecrement = 0.5f;
    public float minimumSpawnDuration = 0.5f;

    private float resetTimer = 3f;

    public float gameTimer = 15f;
    public float gameTimerDecrement = 1f;

    public Player player;

    public TextMesh infoText;

    private Mole[] moles;

    public float spawnTimer = 0f;
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
       /// moles[Random.Range(0,moles.Length )].Rise();       for understanding the script
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
          

            gameTimer-= gameTimerDecrement;
            if (gameTimer > 0f)
            {
                moles[Random.Range(0, moles.Length)].Rise();

                spawnDuration -= spawnDecrement;
                if (spawnDuration < minimumSpawnDuration)
                {
                    spawnDuration = minimumSpawnDuration;
                }

                spawnTimer = spawnDuration;
                infoText.text = "Hit all the moles\n Time: " + Mathf.Floor(gameTimer)+"\n Your Score: "+player.score;
            }
            else
            {
                infoText.text = "Game Over!\n Your Score: " + Mathf.Floor(player.score);

                resetTimer -= Time.deltaTime;
                if (resetTimer <= 0f)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
