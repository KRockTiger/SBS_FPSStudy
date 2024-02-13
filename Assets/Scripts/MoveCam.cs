using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] private float roundSpeed = 1f; //카메라 회전 속도

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, roundSpeed * Time.deltaTime);
            //transform.RotateAround(); => 정해진 좌표 혹은 오브젝트를 기준으로 현 오브젝트가 그 주위에 회전하는 코드
            //Vector3.up을 회전방향으로 사용한다면 반시계방향으로 회전한다.
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(Vector3.zero, Vector3.down, roundSpeed * Time.deltaTime);
        }
    }
}
