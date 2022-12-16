using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 60f;   // 맵의 회전 속도

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f); // y축 기준으로 맵을 회전
    }
}
