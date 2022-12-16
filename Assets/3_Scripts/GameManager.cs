using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameOver;

    public Transform startPos;
    public GameObject[] playerPrefabs;
    SelectCharacter character;

    public GameObject stopPanel;

    public GameObject charPanel;

    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<SelectCharacter>();

        Time.timeScale = 1.0f;
        surviveTime = 0;
        isGameOver = false;

        if(character.playerNum == 1)
        {
            Instantiate(playerPrefabs[0], startPos.position, Quaternion.identity);
        }
        if(character.playerNum == 2)
        {
            Instantiate(playerPrefabs[1], startPos.position, Quaternion.identity);
        }

        charPanel = GameObject.FindGameObjectWithTag("Panel");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;

            timeText.text = "Time: " + (int)surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("01_Play");
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0.0f;
            stopPanel.SetActive(true);
        }
    }

    public void EndGame()
    {
        Time.timeScale = 0.0f;

        isGameOver = true;

        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void Resume() 
    {
        Time.timeScale = 1.0f;
        stopPanel.SetActive(false);
    }

    public void CharacterChanger()
    {
        Destroy(charPanel.gameObject);
        stopPanel.SetActive(false);
        SceneManager.LoadScene("00_Main");
    }    

}
