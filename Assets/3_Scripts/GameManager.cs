using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverText;                    // GameOver UI 출력 텍스트
    public Text timeText;                              // 시간 출력 UI
    public Text recordText;                            // 기록 출력 UI

    private float surviveTime;                         // 기록 갱신을 위해 필요한 생존 시간 변수
    private bool isGameOver;                           // 게임오버 체크용 bool 변수

    public Transform startPos;                         // 캐릭터 생성 위치를 위한 Transform
    public GameObject[] playerPrefabs;                 // 캐릭터 선택에 의해 생성될 player prefabs
    SelectCharacter character;                         // player의 정보 값을 담은 class

    public GameObject stopPanel;                       // 일시 정지 버튼
    public GameObject charPanel;                       // player의 정보를 담고 있는 게임 오브젝트

    void Start()
    {
        character = FindObjectOfType<SelectCharacter>();   // play Scene을 실행시키면 Player정보가 담긴 class를 찾는다.

        Time.timeScale = 1.0f;                             // 게임이 종료됬을 때 멈추었던 시간을 다시 실행
        surviveTime = 0;                                   // 생존 시간 초기화
        isGameOver = false;                                // 게임오버 bool 초기화

        // playerNum에 따른 캐릭터 생성 로직
        if(character.playerNum == 1)                       
        {
            Instantiate(playerPrefabs[0], startPos.position, Quaternion.identity);
        }
        if(character.playerNum == 2)
        {
            Instantiate(playerPrefabs[1], startPos.position, Quaternion.identity);
        }

        // playerNum의 정보를 담고 있는 Panel GameObject
        charPanel = GameObject.FindGameObjectWithTag("Panel");
    }

    void Update()
    {
        if (!isGameOver)  // 게임이 끝나지 않았을 때 시간이 계속 증가
        {
            surviveTime += Time.deltaTime;

            timeText.text = "Time: " + (int)surviveTime;
        }
        else  // 게임이 끝나고 R키를 누르면 씬 재실행
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("01_Play");
            }
        }

        if (Input.GetButtonDown("Cancel"))   // ESC키를 누를 경우 일시정지
        {
            Time.timeScale = 0.0f;
            stopPanel.SetActive(true);
        }
    }

    public void EndGame()                   // 게임 종료 메서드. 
    {
        Time.timeScale = 0.0f;

        isGameOver = true;

        gameOverText.SetActive(true);      // 재시작 UI 출력

        float bestTime = PlayerPrefs.GetFloat("BestTime");  // 저장된 최고 기록 변수

        if(surviveTime > bestTime)  // 현재 기록과 최고 기록을 비교한다.
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);  // 갱신되었다면 현재 기록을 최고 기록으로 저장한다.
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }

    public void OnApplicationQuit()  // 게임 종료 버튼
    {
        Application.Quit();
    }

    public void Resume()            // 게임 재실행 버튼
    {
        Time.timeScale = 1.0f;
        stopPanel.SetActive(false);
    }

    public void CharacterChanger()   // 캐릭터 변경 버튼
    {
        Destroy(charPanel.gameObject);
        stopPanel.SetActive(false);
        SceneManager.LoadScene("00_Main");
    }    

}
