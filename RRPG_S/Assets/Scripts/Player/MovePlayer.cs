using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MovePlayer : MonoBehaviour
{
    #region 변수들 모음

    #region ControlManager 에서 값을 저장할 변수들
    [HideInInspector] public  KeyCode    foward         = KeyCode.None;
    [HideInInspector] public  KeyCode    backward       = KeyCode.None;
    [HideInInspector] public  KeyCode    left           = KeyCode.None;
    [HideInInspector] public  KeyCode    right          = KeyCode.None;
    [HideInInspector] public  KeyCode    dash           = KeyCode.None;
    #endregion

    #region 게임 오브젝트 변수
    [Header("MovePlayer 코드 붙은 오브젝트의 자식 오브젝트")]
    [SerializeField]  private GameObject player         = null;
    [SerializeField]  private Transform  cam            = null;
    #endregion

    #region 일반 변수
    [SerializeField]  private float      moveSpeed      = 1.54f;
    [SerializeField]  private float      turnSmoothTime = 0.1f;
                      private float      zMove          = 0.0f;
                      private float      xMove          = 0.0f;
                      private float      turnSmoothVelocity;  // SmoothDampAngle 에서 저장 용도로 사용하는 변수. 다른 곳에서 사용하지 않음.
                      private float      turnSmoothVelocity2; // SmoothDampAngle 에서 저장 용도로 사용하는 변수. 다른 곳에서 사용하지 않음.
    #endregion

    #endregion

    private void Start()
    {
        #region 유니티 디버그 용
#if UNITY_EDITOR
        bool isKeyOK = (foward != KeyCode.None) || (backward != KeyCode.None) || (left != KeyCode.None) || (right != KeyCode.None);
        if (!isKeyOK)
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
        #region 변수
            Vector3 move;
            float   targetAngle;
            float   angle;
            float   turnPlayer;
        #endregion

        #region 플레이어 움직임 인풋
            zMove = Input.GetKey(foward) ? 1.0f : 0.0f;
            xMove = Input.GetKey(right)  ? 1.0f : 0.0f;

            // 위에서 인풋이 있는데 아레에서 없으면 움직이지 않아서,.
            if (xMove == 0)
                xMove = Input.GetKey(left)     ? -1.0f : 0.0f;
            if (zMove == 0)
                zMove = Input.GetKey(backward) ? -1.0f : 0.0f;

            // 만약 w + s 또는 a + d 인풋이 발생한 경우 -> 움직이지 않음.
            zMove = Input.GetKey(foward) && Input.GetKey(backward) ? 0.0f : zMove;
            xMove = Input.GetKey(right)  && Input.GetKey(left)     ? 0.0f : xMove;
        #endregion
        
        // 인풋이 없으면 처리하지 않아도 되는 것들
        if((xMove != 0) || (zMove != 0))
        {
        #region 플레이어 움직임 처리
            targetAngle = Mathf.Atan2(xMove, zMove) * Mathf.Rad2Deg + transform.rotation.eulerAngles.y;
            angle       = Mathf.SmoothDampAngle(player.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            turnPlayer  = Mathf.SmoothDampAngle(transform.eulerAngles.y, cam.transform.rotation.eulerAngles.y, ref turnSmoothVelocity2, turnSmoothTime);
            move        = new Vector3(xMove, 0.0f, zMove).normalized;
        
        #endregion

        #region 플레이어 움직임 실행
            player.transform.rotation = Quaternion.Euler(0.0f, angle,      0.0f);
            transform.rotation        = Quaternion.Euler(0.0f, turnPlayer, 0.0f);
            transform.Translate(move * moveSpeed * Time.deltaTime);
        #endregion
        }
    }

    #region 대쉬 함수
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
