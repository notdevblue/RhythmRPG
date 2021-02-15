using UnityEngine;

[System.Serializable]
public struct PlayerKeyData
{
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode dash;
}

[System.Serializable]
public struct CameraKeyData
{
    public KeyCode switchSide;
}