using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    
    [SerializeField]
    private int powerupID; // 0 = TripleShot 1 = Speed 2 = Shields

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void /// <summary>
                 /// Sent when another object enters a trigger collider attached to this
                 /// object (2D physics only).
                 /// </summary>
                 /// <param name="other">The other Collider2D involved in this collision.</param>
    OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch(powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    default:
                        //something
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
