using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject objDynamic; //생성될 오브젝트를 담을 부모 오브젝트
    [SerializeField] private GameObject objHitHole; //사격 이미지 프리팹
    [SerializeField] private Transform trsTarget; //타겟

    short shootCount = 0;

    private void Update()
    {
        LookTarget();
        ShootTarget();
    }

    /// <summary>
    /// 타겟을 바라보게 하는 함수
    /// </summary>
    private void LookTarget()
    {
        if (trsTarget == null) //만약 타겟이 없으면 함수 막기
        {
            return;
        }

        transform.LookAt(trsTarget);
    }

    /// <summary>
    /// 타겟을 향해 발사하게 하는 함수
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
    /// 총이 발사됬을 때 흔적을 남기게 하는 함수
    /// </summary>
    private void CreateHole(RaycastHit _hit)
    {
        GameObject objHithole = Instantiate(objHitHole, _hit.point + _hit.normal * 0.0001f,
                                Quaternion.FromToRotation(Vector3.forward, _hit.normal), objDynamic.transform);
                                //1. + _hit.normal을 넣어서 쏜 방향으로 나오게 해주고 * 0.0001f로 그 수치를 살짝나오게 해준다.
                                //2. FromToRatation(Vector3.forward, _hit.normal)로 쏜 Ray와 부딪힌 면의 각도를 계산하여
                                //   방향을 회전시켜준다.
        SpriteRenderer sr = objHithole.GetComponent<SpriteRenderer>();
        sr.sortingOrder = shootCount++;

        if (shootCount >= 32767)
        {
            shootCount = 0;
        }

        //Destroy(objHithole, 3f);
    }
}
