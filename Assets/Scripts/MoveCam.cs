using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] private float roundSpeed = 1f; //ī�޶� ȸ�� �ӵ�

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(Vector3.zero, Vector3.up, roundSpeed * Time.deltaTime);
            //transform.RotateAround(); => ������ ��ǥ Ȥ�� ������Ʈ�� �������� �� ������Ʈ�� �� ������ ȸ���ϴ� �ڵ�
            //Vector3.up�� ȸ���������� ����Ѵٸ� �ݽð�������� ȸ���Ѵ�.
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(Vector3.zero, Vector3.down, roundSpeed * Time.deltaTime);
        }
    }
}
