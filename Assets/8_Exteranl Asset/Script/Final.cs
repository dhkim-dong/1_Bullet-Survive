using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject gamebg;

    // Start is called before the first frame update
    void Start()
    {
        gamebg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gamebg.SetActive(true);
    }
}
