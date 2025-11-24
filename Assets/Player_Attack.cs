using UnityEngine;

public class Player_AutoAttack : MonoBehaviour, IAttackService
{
    [SerializeField] GetNearestGameObjectService GetNearestGameObjectService;
    [SerializeField] Weapon_Base weapon;

    [Header("Stats")]
    [Tooltip("Thời gian chờ giữa 2 lần bắn (Giây). Ví dụ: 0.2 là bắn nhanh, 5 là bắn chậm")]
    [SerializeField] float attackCooldown = 0.5f; // Đổi tên cho rõ nghĩa (đây là Cooldown, không phải Speed)

    private float currentTimer = 0f; // Biến này dùng để đếm, không hiển thị trong Inspector

    void Start()
    {
        GetNearestGameObjectService = GetComponentInChildren<GetNearestGameObjectService>();
        weapon = GetComponentInChildren<Weapon_Base>();

        // Để khi vào game có thể bắn được ngay lập tức
        currentTimer = 0f;
    }

    void Update()
    {
        // 1. Luôn luôn trừ thời gian đếm ngược, bất kể có quái hay không
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }

        // 2. Gọi hàm tấn công
        Attack(GetNearestGameObjectService.Nearest);
    }

    public void Attack(GameObject target)
    {
        // Nếu mục tiêu không tồn tại thì không làm gì cả
        if (target == null) return;

        // Nếu đã hết thời gian chờ -> Bắn
        if (currentTimer <= 0)
        {
            weapon.Shot(target);

            // 3. Reset bộ đếm về giá trị Cooldown gốc
            // Quan trọng: Dùng biến attackCooldown chứ không điền số cứng (5f)
            currentTimer = attackCooldown;
        }
    }
}

public interface IAttackService
{
    void Attack(GameObject target);
}