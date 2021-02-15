using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if !UNITY_EDITOR  || !UNITY_STANDALONE
#error This game only supports PC version.
#endif
// 조작 키 설정 클레스
public class ControlManager : MonoBehaviour
{
    [SerializeField] private PlayerKeyData pConData;
    [SerializeField] private CameraKeyData camConData;
                     private MovePlayer    pConSet = null;



    private void Awake()
    {
        pConSet = FindObjectOfType<MovePlayer>();

        pConSet.foward   = pConData.forward;
        pConSet.backward = pConData.backward;
        pConSet.left     = pConData.left;
        pConSet.right    = pConData.right;
        pConSet.dash     = pConData.dash;
    }


}
