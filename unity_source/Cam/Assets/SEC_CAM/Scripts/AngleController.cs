using UnityEngine;

public class AngleController : MonoBehaviour
{
    public Transform camera_angle;

    public void cam_rotateZ()
    {
        if (camera_angle != null)
        {
            // 現在の角度に +15度回転（Z軸）
            Vector3 angles = camera_angle.localEulerAngles;

            // Zを -180〜180 に正規化
            float z = Mathf.Repeat(angles.z + 180f, 360f) - 180f;

            // 15度回転させる
            z = Mathf.Clamp(z + 15f, -75f, 75f);

            // Xも保持してQuaternionでセット（Yは不要なら0でもOK）
            float x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;
            camera_angle.localRotation = Quaternion.Euler(x, 0f, z);
        }
    }
    public void cam_rotateZ2()
    {
        if (camera_angle != null)
        {
            // 現在の角度に -15度回転（Z軸）
            Vector3 angles = camera_angle.localEulerAngles;

            // Zを -180〜180 に正規化
            float z = Mathf.Repeat(angles.z + 180f, 360f) - 180f;

            // 15度回転させる
            z = Mathf.Clamp(z - 15f, -75f, 75f);

            // Xも保持してQuaternionでセット（Yは不要なら0でもOK）
            float x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;
            camera_angle.localRotation = Quaternion.Euler(x, 0f, z);
        }
    }
    public void cam_rotateX()
    {
        if (camera_angle != null)
        {
            // 現在の角度に +15度回転（X軸）
            Vector3 angles = camera_angle.localEulerAngles;

            // Xを -180〜180 に正規化
            float x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;

            // 15度回転させる
            x = Mathf.Clamp(x + 15f, -75f, 75f);  // ← プラス方向に回転するなら +15f

            // Zも保持してQuaternionでセット（Yは0でもOK）
            float z = Mathf.Repeat(angles.z + 180f, 360f) - 180f;
            camera_angle.localRotation = Quaternion.Euler(x, 0f, z);
        }
    }
    public void cam_rotateX2()
    {
        if (camera_angle != null)
        {
            // 現在の角度に -15度回転（X軸）
            Vector3 angles = camera_angle.localEulerAngles;

            // Xを -180〜180 に正規化
            float x = Mathf.Repeat(angles.x + 180f, 360f) - 180f;

            // 15度回転させる
            x = Mathf.Clamp(x - 15f, -75f, 75f);  // ← プラス方向に回転するなら +15f

            // Zも保持してQuaternionでセット（Yは0でもOK）
            float z = Mathf.Repeat(angles.z + 180f, 360f) - 180f;
            camera_angle.localRotation = Quaternion.Euler(x, 0f, z);
        }
    }
}
