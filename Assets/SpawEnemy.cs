using UnityEngine;
using Bang.Lib.ObjectPooling; // Dùng lại thư viện Pool của bạn

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject enemyPrefab;    // Prefab quái
    public float minSpawnRadius = 8f; // Khoảng cách tối thiểu (để không đẻ ngay trước mặt)
    public float maxSpawnRadius = 12f;// Khoảng cách tối đa (để không đẻ quá xa camera)

    [Header("Timing")]
    public float spawnInterval = 2f;  // Cứ 2 giây đẻ 1 con
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        
        Vector2 playerPos = Player_Manager.Instance.Player.transform.position;

        // BƯỚC 2: Tạo một điểm ngẫu nhiên trong hình tròn bán kính = 1
        Vector2 randomPoint = Random.insideUnitCircle;

        // BƯỚC 3: "Chuẩn hóa" để lấy hướng (đưa độ dài về 1)
        // Nếu bạn không normalize, quái có thể spawn ngay tâm (trùng người chơi)
        Vector2 randomDirection = randomPoint.normalized;

        // BƯỚC 4: Random khoảng cách từ Min đến Max
        float randomDistance = Random.Range(minSpawnRadius, maxSpawnRadius);

        // BƯỚC 5: Tính toạ độ cuối cùng
        Vector2 spawnPos = playerPos + (randomDirection * randomDistance);

        // BƯỚC 6: Sinh quái ra từ Pool
        // (Lưu ý: Nếu game 2D top-down thì Z=0, game 3D thì cần thay đổi Vector3)
        var enemy = Pool_Manager.Instance.GetFromPool(enemyPrefab);
        enemy.transform.position = spawnPos;
        enemy.transform.rotation = Quaternion.identity; // Không xoay

        // Reset lại quái (nếu cần thiết, ví dụ hồi máu lại cho quái vừa lấy từ pool)
        // enemy.GetComponent<EnemyHealth>().ResetHealth();
    }

    // Vẽ vòng tròn trong Editor để dễ căn chỉnh
    void OnDrawGizmosSelected()
    {
        // Lấy vị trí để vẽ (nếu đang chạy game thì lấy Player, không thì lấy Spawner)
        Vector3 center = Application.isPlaying ? Player_Manager.Instance.Player.transform.position : transform.position;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(center, minSpawnRadius); // Vòng an toàn
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, maxSpawnRadius); // Vòng giới hạn
    }
}