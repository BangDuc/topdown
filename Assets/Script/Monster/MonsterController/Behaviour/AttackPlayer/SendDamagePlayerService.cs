using UnityEngine;

public class SendDamageService : MonoBehaviour, ISendDamage
{
    [SerializeField] float _damage;
    [SerializeField] IServiceDetectPlayer detect_Player_Service;

    public void setDamage(float damage)
    {
        _damage= damage;
    }

    public void SendDamage(GameObject target, float Damage)
    {
       
        if(target.TryGetComponent<ITargetable>(out var targetable))
        {
            targetable.GetDamage(Damage);
        }
    }

}