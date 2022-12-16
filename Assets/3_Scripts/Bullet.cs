using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigid;

    SpawnEnemy bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = FindObjectOfType<SpawnEnemy>();

        bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * bulletSpeed.speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                player.Die();
            }
        }
    }
}
