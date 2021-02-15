using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 조작 키 설정 클레스
public class ControlManager : MonoBehaviour
{
    [SerializeField] private PlayerKeyData pConData;
    [SerializeField] private CameraKeyData camConData;

    private MovePlayer pConSet = null;



    private void Awake()
    {
        pConSet.foward = pConData.forward;
        pConSet.backward = pConData.backward;
        pConSet.left = pConData.left;
        pConSet.right = pConData.right;
    }


}
