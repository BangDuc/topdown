using UnityEngine;

public class Player_AutoAttack : MonoBehaviour, IAttackService
{
    [SerializeField] GetNearestGameObjectService GetNearestGameObjectService;
    [SerializeField] IWeapon weapon;
    
    [SerializeField] float attackCooldown = 0.5f;

    private float currentTimer = 0f; // Biến này dùng để đếm, không hiển thị trong Inspector

    void Start()
    {
        GetNearestGameObjectService = GetComponentInChildren<GetNearestGameObjectService>();
        weapon = GetComponentInChildren<IWeapon>();
        currentTimer = 0f;
    }

    void Update()
    {
        if (weapon == null) return;
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
            weapon.Attack(target, 10f);
            currentTimer = attackCooldown;
        }
    }
}

public interface IAttackService
{
    void Attack(GameObject target);
}