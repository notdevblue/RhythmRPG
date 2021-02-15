using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MovePlayer : MonoBehaviour
{
    #region ControlManager 에서 값을 저장할 변수들
    public KeyCode foward   = KeyCode.None;
    public KeyCode backward = KeyCode.None;
    public KeyCode left     = KeyCode.None;
    public KeyCode right    = KeyCode.None;
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

    


}
