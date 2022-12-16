using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    // 필요 속성 : 생성할 총알. 총알 생성 주기, 총알이 추적할 대상

    [SerializeField] private GameObject bulletPrefab;          // 발사할 총알 프리펩. 총알의 종류가 다양하다면 배열로 선언
    [SerializeField] private float spawnRateMin = 0.5f;        // 총알 생성 주기의 최소 시간
    [SerializeField] private float spawnRateMax = 3f;          // 총알 생성 주기의 최대 시간

    private Transform target;                                  // 총알이 추적할 대상
    private float spawnRate;                                   // 랜덤한 총알 생성 주기의 값을 받을 spawnRate 변수
    private float timeAfterSpawn;                              // 매 프레임 Time.deltaTime만큼 증가시켜 spawnRate와 비교할 변수

    private void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);         // spawnRate의 최소 ~ 최대 값을 Random.Range로 받아온다.

        target = FindObjectOfType<PlayerController>().transform;      // target의 대상자는 PlayerController를 가진 객체. 해당 게임의 Player는 하나이므로, 플레이어 하나만 쫓는다.
    }

    private void Update()
    {
        timeAfterSpawn += Time.deltaTime;                             // 매 프레임 시간을 증가시킨다.

        if (timeAfterSpawn >= spawnRate)                               // spawnRate의 시간을 초과한다면
        {
            timeAfterSpawn = 0;                                       // 무한 반복을 위해 0으로 초기화

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);  // 총알을 생성한다

            bullet.transform.LookAt(target);  // 총알은 forward 방향으로 이동하기 때문에, 생성할 때의 target방향으로 이동한다.

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);     // 새로운 spawnRate 값을 랜덤하게 입력 받는다.
        }
    }
}
