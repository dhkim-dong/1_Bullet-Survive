using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;                    // GameOver UI ��� �ؽ�Ʈ
    public Text timeText;                              // �ð� ��� UI
    public Text recordText;                            // ��� ��� UI

    private float surviveTime;                         // ��� ������ ���� �ʿ��� ���� �ð� ����
    private bool isGameOver;                           // ���ӿ��� üũ�� bool ����

    public Transform startPos;                         // ĳ���� ���� ��ġ�� ���� Transform
    public GameObject[] playerPrefabs;                 // ĳ���� ���ÿ� ���� ������ player prefabs
    SelectCharacter character;                         // player�� ���� ���� ���� class

    public GameObject stopPanel;                       // �Ͻ� ���� ��ư
    public GameObject charPanel;                       // player�� ������ ��� �ִ� ���� ������Ʈ

    void Start()
    {
        character = FindObjectOfType<SelectCharacter>();   // play Scene�� �����Ű�� Player������ ��� class�� ã�´�.

        Time.timeScale = 1.0f;                             // ������ ������� �� ���߾��� �ð��� �ٽ� ����
        surviveTime = 0;                                   // ���� �ð� �ʱ�ȭ
        isGameOver = false;                                // ���ӿ��� bool �ʱ�ȭ

        // playerNum�� ���� ĳ���� ���� ����
        if(character.playerNum == 1)                       
        {
            Instantiate(playerPrefabs[0], startPos.position, Quaternion.identity);
        }
        if(character.playerNum == 2)
        {
            Instantiate(playerPrefabs[1], startPos.position, Quaternion.identity);
        }

        // playerNum�� ������ ��� �ִ� Panel GameObject
        charPanel = GameObject.FindGameObjectWithTag("Panel");
    }

    void Update()
    {
        if (!isGameOver)  // ������ ������ �ʾ��� �� �ð��� ��� ����
        {
            surviveTime += Time.deltaTime;

            timeText.text = "Time: " + (int)surviveTime;
        }
        else  // ������ ������ RŰ�� ������ �� �����
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("01_Play");
            }
        }

        if (Input.GetButtonDown("Cancel"))   // ESCŰ�� ���� ��� �Ͻ�����
        {
            Time.timeScale = 0.0f;
            stopPanel.SetActive(true);
        }
    }

    public void EndGame()                   // ���� ���� �޼���. 
    {
        Time.timeScale = 0.0f;

        isGameOver = true;

        gameOverText.SetActive(true);      // ����� UI ���

        float bestTime = PlayerPrefs.GetFloat("BestTime");  // ����� �ְ� ��� ����

        if(surviveTime > bestTime)  // ���� ��ϰ� �ְ� ����� ���Ѵ�.
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);  // ���ŵǾ��ٸ� ���� ����� �ְ� ������� �����Ѵ�.
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }

    public void OnApplicationQuit()  // ���� ���� ��ư
    {
        Application.Quit();
    }

    public void Resume()            // ���� ����� ��ư
    {
        Time.timeScale = 1.0f;
        stopPanel.SetActive(false);
    }

    public void CharacterChanger()   // ĳ���� ���� ��ư
    {
        Destroy(charPanel.gameObject);
        stopPanel.SetActive(false);
        SceneManager.LoadScene("00_Main");
    }    

}
