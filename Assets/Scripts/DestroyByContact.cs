using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public float life;
    public int scoreValue;

    private GameController gameController;

    void Start(){
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        if (gameController == null)
            Debug.Log("Cannot find 'GameController' Script");
    }

	void OnTriggerEnter(Collider other){
        if (other.tag.Equals("Boundary")){
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag.Equals("Player")){
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver ();
        }else{
            gameController.AddScore(scoreValue);
        }
        Destroy(other.gameObject);
        if (--life == 0)
            Destroy(gameObject);
    }
}
