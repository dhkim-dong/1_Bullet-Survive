using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 필요 속성 : 총알의 속도
    private Rigidbody bulletRigid; 

    private SpawnEnemy bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = FindObjectOfType<SpawnEnemy>();                  // 필요 컴포넌트 찾기
        bulletRigid = GetComponent<Rigidbody>();                       // GameObject의 Rigidbody 찾기
        bulletRigid.velocity = transform.forward * bulletSpeed.speed;  // 생성 후 총알의 전방 방향으로 이동

        Destroy(gameObject, 3f);                                       // 생성 후 3초 뒤 파괴
    }

    private void OnTriggerEnter(Collider other)                        // 충돌 트리거
    {
        if(other.tag == "Player")                                      // Tag가 플레이어 인가요?
        {
            PlayerController player = other.GetComponent<PlayerController>();  // PlayerController 클래스를 담을 변수 player

            if(player != null)    // PlayerController class가 없다면 실행하지 말 것 (방어코드)
            {
                player.Die();     // 사망 메서드 실행
            }
        }
    }
}
