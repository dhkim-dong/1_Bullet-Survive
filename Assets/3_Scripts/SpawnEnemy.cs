using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] enemyPos;       // Level 마다 Enemy의 생성될 위치를 다르게 하기 위해서 배열로 생성 위치를 저장
    public GameObject enemyPrefab;     // BulletSpawner의 프리펩을 불러옵니다.

    public int gameLevel;              // 현재 Game의 Level입니다.
    private int maxLevel;              // Game의 최대 Level입니다. gameLevel은 maxLevel을 초과할 수 없습니다.
    public float levelUpTime;          // 레벨업을 하기 위한 필요 시간입니다.
    public float timeDefault;          // levelUpTime을 체크하는 시간입니다.

    public bool isLvUp;                // 레벨 증가를 체크하는 Bool 변수입니다.
    public Text lvTxt;                 // Level UI 출력 text입니다.

    public float speed = 8f;           // 총알의 속도 값입니다.

    void Start()
    {
        gameLevel = 1;
    }

    void Update()
    {
        lvTxt.text = "Level : " + gameLevel;                     // UI 출력

        timeDefault += Time.deltaTime;                           // Time Check

        if(timeDefault >= levelUpTime)                           // 정한 시간이 지나면 Level이 증가
        {
            timeDefault = 0f;

            gameLevel++;
            isLvUp = true;
        }

        if (isLvUp)                                              // 레벨이 증가 한 경우
        {
            if(gameLevel % 2 == 0)                               // 짝수 레벨마다 Enemy가 1 추가
            {
                Instantiate(enemyPrefab, enemyPos[(gameLevel - 2)%4].position, Quaternion.identity);
                isLvUp = false;
            }
            else                                                 // 홀수 레벨 마다 Bullet 속도 증가
            {
                speed += 1f;
                isLvUp = false;
            }
        }
    }
}
