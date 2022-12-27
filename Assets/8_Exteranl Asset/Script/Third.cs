using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third : MonoBehaviour
{

    public GameObject blk;

    // Start is called before the first frame update
    void Start()
    {
        blk.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        blk.SetActive(true);
    }
}
