using UnityEngine;

public class AttackPlayerService : MonoBehaviour, IAttackService
{
    [SerializeField]float _atkspeed;
    [SerializeField] float _currenttime=0f;
    public float AttackSpeed { get => _atkspeed; set => _atkspeed=value; }
    public float CurrentTimer { get => _currenttime; set => _currenttime= value; }

    public void Attack(GameObject target)
    {
        Debug.Log("Attack Player");
        _currenttime = 0;
    }

    public bool CanAttack()
    {
        if (_currenttime >= _atkspeed)
        {
            return true;
        }
        return false;
    }
    void Update()
    {
        _currenttime += Time.deltaTime;
        
    }
    void Start()
    {
        _currenttime = 0f;
    }
}
