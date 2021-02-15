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
    [HideInInspector] public  KeyCode    dash       = KeyCode.None;
    #endregion
    #region 게임 오브젝트 변수
    [SerializeField]  private GameObject controlObj = null;
    #endregion
    #region 일반 변수
    [SerializeField]  private float      moveSpeed  = 1.54f;
                      private float      zMove = 0.0f;
                      private float      xMove = 0.0f;
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


    #region 플레이어 움직임 함수
    private void Move()
    {
        
        zMove = Input.GetKey(foward)   ?  1.0f : 0.0f;
        xMove = Input.GetKey(right)    ?  1.0f : 0.0f;

        if (xMove == 0)
            xMove = Input.GetKey(left)     ? -1.0f : 0.0f;
        if(zMove == 0)
            zMove = Input.GetKey(backward) ? -1.0f : 0.0f;

        zMove = Input.GetKey(foward) && Input.GetKey(backward) ? 0.0f : zMove;
        xMove = Input.GetKey(right)  && Input.GetKey(left)     ? 0.0f : xMove;

        Vector3 move = new Vector3(xMove, 0.0f, zMove).normalized;

        transform.Translate(move * moveSpeed * Time.deltaTime);
    }

    #region 대쉬
    private void Dash()
    {

    }
    private void DashCooldown()
    {

    }
    #endregion

    #endregion



    private void Update()
    {
        // 만약에 스턴기 같은 게 있을수도 있으니
        if (true)
            Move();
    }


}
