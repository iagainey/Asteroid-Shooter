using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public GameObject enery;

    public int hazardCount;
    public float startTime;
    public float spawnTime;
    public float waveCoolDown;

    public GUIText  scoreText;
    public GUIText  restartText;
    public GUIText  gameOverText;
    private int      score;

    private bool gameOver;
    private bool restart;
    private float nextSpawn;
    // Use this for initialization
    void Start () {
        gameOver    = false;
        restart     = false;
        gameOverText.text   = "";
        restartText.text    = "";
        StartCoroutine (spawnWaves() );
	}
	
	// Update is called once per frame
	void Update () {
	    if(restart && Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);
	}
    IEnumerator spawnWaves(){
        yield return new WaitForSeconds(startTime);
        while ( true ) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnTime);
            }
            yield return new WaitForSeconds(waveCoolDown);

            if (gameOver){
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score : " + score;
    }
    public void GameOver(){
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
