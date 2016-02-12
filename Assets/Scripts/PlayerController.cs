using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    private Rigidbody rb;
    private AudioSource audio;
    void Start() {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        if ( Input.GetButtonDown("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(
                       shot,
                       shotSpawn.position,
                       shotSpawn.rotation
               );
            audio.Play();
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0.0f, y);
        rb.velocity = movement * speed;

        x *= speed * Time.deltaTime;
        y *= speed * Time.deltaTime;

        rb.position = new Vector3( 
               Mathf.Clamp( //X value
                   rb.position.x, 
                   boundary.xMin, 
                   boundary.xMax), 
               0.0f, //Y Value
               Mathf.Clamp( //Z Value
                   rb.position.z, 
                   boundary.zMin, 
                   boundary.zMax)
             );
        if (rb.position.x > boundary.xMin
            && rb.position.x < boundary.xMax) {
            rb.rotation = Quaternion.Euler(
                   0.0f, 0.0f,
                   rb.velocity.x * -tilt
                 );
        }else{
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
[System.Serializable]
public class Boundary{
    public float xMin, xMax, zMin, zMax;
}