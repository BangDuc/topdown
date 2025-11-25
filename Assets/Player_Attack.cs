using UnityEngine;

public class Player_AutoAttack : MonoBehaviour, IAttackService
{
    [SerializeField] GetNearestGameObjectService GetNearestGameObjectService;
    [SerializeField] IWeapon weapon;
    
    [SerializeField] float AttackSpeed = 1f;

    private float currentTimer = 0f;

    void Start()
    {
        GetNearestGameObjectService = GetComponentInChildren<GetNearestGameObjectService>();
        weapon = GetComponentInChildren<IWeapon>();
        currentTimer = 0f;
    }

    void Update()
    {
        if (weapon == null) return;

        currentTimer += Time.deltaTime;

        Attack(GetNearestGameObjectService.Nearest);
    }

    public void Attack(GameObject target)
    {
        
        if (target == null) return;

        if(currentTimer < AttackSpeed) return;

        currentTimer = 0f;
        weapon.Attack(GetNearestGameObjectService.Nearest, 10f);


    }
}

public interface IAttackService
{
    void Attack(GameObject target);
}