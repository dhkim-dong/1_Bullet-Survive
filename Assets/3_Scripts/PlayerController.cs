using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float p_moveSpeed;
    public Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        p_moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 position = transform.position;

        position.x += horizontal * Time.deltaTime * p_moveSpeed;
        position.z += vertical * Time.deltaTime * p_moveSpeed;

        transform.position = position;

        if(transform.position.y <= -1)
        {
            Die();
        }

        //transform.rotation;

    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();

        gameManager.EndGame();
    }
}
