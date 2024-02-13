using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject objDynamic; //������ ������Ʈ�� ���� �θ� ������Ʈ
    [SerializeField] private GameObject objHitHole; //��� �̹��� ������
    [SerializeField] private Transform trsTarget; //Ÿ��

    short shootCount = 0;

    private void Update()
    {
        LookTarget();
        ShootTarget();
    }

    /// <summary>
    /// Ÿ���� �ٶ󺸰� �ϴ� �Լ�
    /// </summary>
    private void LookTarget()
    {
        if (trsTarget == null) //���� Ÿ���� ������ �Լ� ����
        {
            return;
        }

        transform.LookAt(trsTarget);
    }

    /// <summary>
    /// Ÿ���� ���� �߻��ϰ� �ϴ� �Լ�
    /// </summary>
    private void ShootTarget()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) &&
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10f, LayerMask.GetMask("Target")))
        {
            CreateHole(hit);
        }
    }

    /// <summary>
    /// ���� �߻���� �� ������ ����� �ϴ� �Լ�
    /// </summary>
    private void CreateHole(RaycastHit _hit)
    {
        GameObject objHithole = Instantiate(objHitHole, _hit.point + _hit.normal * 0.0001f,
                                Quaternion.FromToRotation(Vector3.forward, _hit.normal), objDynamic.transform);
                                //1. + _hit.normal�� �־ �� �������� ������ ���ְ� * 0.0001f�� �� ��ġ�� ��¦������ ���ش�.
                                //2. FromToRatation(Vector3.forward, _hit.normal)�� �� Ray�� �ε��� ���� ������ ����Ͽ�
                                //   ������ ȸ�������ش�.
        SpriteRenderer sr = objHithole.GetComponent<SpriteRenderer>();
        sr.sortingOrder = shootCount++;

        if (shootCount >= 32767)
        {
            shootCount = 0;
        }

        //Destroy(objHithole, 3f);
    }
}
