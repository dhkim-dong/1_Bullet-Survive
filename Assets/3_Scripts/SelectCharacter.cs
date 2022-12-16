using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public int playerNum;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectBoy()
    {
        playerNum = 1;
        SceneManager.LoadScene("01_Play");
    }

    public void SelectGirl()
    {
        playerNum = 2;
        SceneManager.LoadScene("01_Play");
    }
}
