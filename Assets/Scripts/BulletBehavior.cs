using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    // when collided with another gameObject
    void OnTriggerEnter2D(Collider2D newCollision)
    {
        if (newCollision.gameObject.layer == LayerMask.NameToLayer("BlockingLayer"))
        {
            // only do stuff if hit an enemy
            if (newCollision.gameObject.tag == "Enemy")
            {
                Enemy enemy = newCollision.gameObject.GetComponent<Enemy>();

                enemy.HitEnemy();

                /*
                // if game manager exists, make adjustments based on target properties
                if (GameManager.gm)
                {
                    GameManager.gm.targetHit(scoreAmount, timeAmount);
                }
                */
            }

            // destroy the bullet
            //Destroy(newCollision.gameObject);

            // destroy self
            Destroy(gameObject);
        }
    }
}
