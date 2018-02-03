using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerupType {normal, wood, metal};
    public PowerupType powerupState = PowerupType.normal;
	void Start () {
		
	}
	

	void Update () {
		
	}

    

    //to detect if the player has hit the powerup
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager pm = other.gameObject.GetComponentInParent<PlayerManager>();
            if (powerupState == PowerupType.normal)
            {
                print(other.gameObject.name);
                print(pm.gameObject.name.ToString());
            }
            if (powerupState == PowerupType.metal)
            {

            }
            if (powerupState == PowerupType.wood)
            {

            }
            this.gameObject.SetActive(false);
        }
    }
}
