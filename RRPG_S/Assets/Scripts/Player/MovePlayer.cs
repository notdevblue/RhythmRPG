using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MovePlayer : MonoBehaviour
{
    #region 변수들 모음
    #region ControlManager 에서 값을 저장할 변수들
    [HideInInspector] public  KeyCode    foward     = KeyCode.None;
    [HideInInspector] public  KeyCode    backward   = KeyCode.None;
    [HideInInspector] public  KeyCode    left       = KeyCode.None;
    [HideInInspector] public  KeyCode    right      = KeyCode.None;
    #endregion
    #region 게임 오브젝트 변수
    [SerializeField]  private GameObject controlObj = null;
    #endregion
    #region 일반 변수
    [SerializeField]  private float      moveSpeed  = 1.5f;


    #endregion
    #endregion

    private void Start()
    {
        #region 유니티 디버그 용
        #if UNITY_EDITOR
        bool isKeyOK = (foward != KeyCode.None) || (backward != KeyCode.None) || (left != KeyCode.None) || (right != KeyCode.None);
        if(!isKeyOK)
        {
            EditorUtility.DisplayDialog("플레이어 입력 키 오류", "비어있는 키가 있습니다.", "확인");
            EditorApplication.isPlaying = false;
        }
        #endif
        #endregion
    }

    private void Move()
    {
        if (Input.GetKey(foward))
        {
            controlObj.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(backward))
        {
            controlObj.transform.Translate(Vector3.back    * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(left))
        {
            controlObj.transform.Translate(Vector3.left    * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(right))
        {
            controlObj.transform.Translate(Vector3.right   * Time.deltaTime * moveSpeed);
        }
    }



    private void Update()
    {
        // 만약에 스턴기 같은 게 있을수도 있으니
        if (true)
            Move();
    }


}
