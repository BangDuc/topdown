using Bang.Lib.ObjectPooling;
using UnityEngine;

public class Weapon_Base : MonoBehaviour
{
    [SerializeField] GameObject Prefab_Bullet;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] float SpeedBullet = 10f; // Nhớ set tốc độ > 0

    public void Shot(GameObject target)
    {
        // 1. Lấy đạn từ Pool
        var bullet = Pool_Manager.Instance.GetFromPool(Prefab_Bullet.gameObject);

        // 2. Đặt vị trí xuất phát
        bullet.transform.position = SpawnPoint.transform.position;

        // 3. Tính toán hướng bắn (Quy tắc: Đích - Đầu)
        Vector2 direction = target.transform.position - SpawnPoint.transform.position;

        // 4. Lấy Rigidbody
        var rb = bullet.gameObject.GetComponent<Rigidbody2D>();

        // --- QUAN TRỌNG: Reset vận tốc cũ (do dùng lại đạn từ Pool) ---
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // 5. Gán vận tốc để đạn bay đi
        // .normalized để giữ độ dài bằng 1, sau đó nhân với tốc độ mong muốn
        rb.linearVelocity = direction.normalized * SpeedBullet;

        // (Tùy chọn) Xoay viên đạn hướng về phía mục tiêu
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}