using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zero : MonoBehaviour
{
    public GameObject myh;
    // Start is called before the first frame update
    void Start()
    {
        myh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        myh.SetActive(true);
    }
}
