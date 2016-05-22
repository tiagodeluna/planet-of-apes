using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    // Reference to projectile prefab to shoot
    public Rigidbody2D projectile;
    public float speed = 20.0f;

    // Reference to AudioClip to play
    public AudioClip shootSFX;

    private Player player;

    void Awake()
    {
        player = transform.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // Detect if fire button is pressed
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            // if projectile is specified
            if (projectile)
            {
                Rigidbody2D newProjectile;

                if (player.IsFacingRight())
                {
                    // Instantiate the rocket facing right and set it's velocity to the right.
                    //newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
                    newProjectile = Instantiate(projectile, transform.position + Vector3.right, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                    newProjectile.velocity = new Vector2(speed, 0);
                }
                else
                {
                    // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                    newProjectile = Instantiate(projectile, transform.position + Vector3.left, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                    newProjectile.velocity = new Vector2(-speed, 0);
                }

                // play sound effect if set
                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                      // play the sound clip through the AudioSource component on the gameobject.
                      // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
                    }
                }
            }
        }
    }
}
