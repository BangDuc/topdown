using UnityEngine;

public class AttackPlayerService : MonoBehaviour, IAttackService
{
    [SerializeField]float _atkspeed;
    [SerializeField] float _currenttime=0f;
    [SerializeField] float _damage=10f;
    [SerializeField] ISendDamage sendDamagePlayer;
    [SerializeField] IServiceDetectPlayer detectPlayer;
    [SerializeField] IAnimationControl animationControl;
    public float AttackSpeed { get => _atkspeed; set => _atkspeed=value; }
    public float CurrentTimer { get => _currenttime; set => _currenttime= value; }
    
    public void Attack(GameObject target)
    {
        if (!detectPlayer.isDetect()) return;
        sendDamagePlayer.SendDamage(target, _damage);
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
        sendDamagePlayer= GetComponent<ISendDamage>();
        detectPlayer = GetComponent<IServiceDetectPlayer>();
        _currenttime = 0f;
    }

}
