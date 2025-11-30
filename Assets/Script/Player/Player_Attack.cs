using UnityEngine;

public class Player_AutoAttack : MonoBehaviour, IAttackService
{
    [SerializeField] GetNearestGameObjectService GetNearestGameObjectService;
    [SerializeField] IWeapon weapon;
    
    [SerializeField] float _attackSpeed = 1f;

    private float _currentTimer = 0f;

    
    public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
    public float CurrentTimer { get => _currentTimer; set => _currentTimer=value; }

    void Start()
    {
        GetNearestGameObjectService = GetComponentInChildren<GetNearestGameObjectService>();
        weapon = GetComponentInChildren<IWeapon>();
        _currentTimer = 0f;
    }

    void Update()
    {
        if (weapon == null) return;

        _currentTimer += Time.deltaTime;
        if (CanAttack())
        {
            Attack(GetNearestGameObjectService.Nearest);
        }
        
    }

    public void Attack(GameObject target)
    {
        if (target == null) return;
        weapon.Attack(GetNearestGameObjectService.Nearest, 10f);
    }

    public bool CanAttack()
    {
        if (_currentTimer < AttackSpeed) return false;
        _currentTimer = 0f;
        return true;
    }
}

public interface IAttackService
{
    void Attack(GameObject target);
    float AttackSpeed { get; set; }
    float CurrentTimer { get; set; }
    bool CanAttack();
}