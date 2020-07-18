using UnityEngine;

public class CamControl : MonoBehaviour
{
    [Header("追蹤目標")]
    public Transform target;
    [Header("追蹤速度")]
    public float speed = 5;
    [Header("攝影機 Y 軸限制")]
    public Vector2 limitY = new Vector2(0, 0.11f);

    /// <summary>
    /// 攝影機追蹤
    /// </summary>
    private void Track()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        b.z = -10;

        // 插值(A, B, 百分比)
        a = Vector3.Lerp(a, b, Time.deltaTime * speed);

        // a.y = 數學函式.夾住(a.y, 最小, 最大)
        a.y = Mathf.Clamp(a.y, limitY.x, limitY.y);

        // 攝影機.座標 = A
        transform.position = a;
    }

    // Update 先執行
    // LateUpdate 後執行
    private void LateUpdate()
    {
        Track();
    }
}
