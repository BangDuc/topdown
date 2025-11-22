using UnityEngine;

public class TestDraw : MonoBehaviour
{
    [Header("Settings")]
    public float detectionRadius = 5f; // Bán kính phát hiện
    public Color gizmoColor = Color.red; // Màu sắc vòng tròn

    // Hàm này CHỈ chạy trong Unity Editor để vẽ debug
    private void OnDrawGizmos()
    {
        // 1. Chọn màu cho cọ vẽ (nên dùng màu trong suốt để dễ nhìn)
        Gizmos.color = new Color(gizmoColor.r, gizmoColor.g, gizmoColor.b, 0.3f);

        // 2. Vẽ một hình cầu đặc (Solid Sphere) tại vị trí quái vật
        Gizmos.DrawSphere(transform.position, detectionRadius);

        // HOẶC: Nếu chỉ muốn vẽ đường viền vòng tròn (Wire Sphere)
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
