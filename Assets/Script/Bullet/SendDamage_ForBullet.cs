
using Bang.Lib.ObjectPooling;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage_ForBullet : MonoBehaviour, ISendDamage
{
    [SerializeField] float Damage;
    [SerializeField]List<string> listTag = new List<string>();

    public void SendDamage(GameObject target, float Damage)
    {
        if (target.TryGetComponent<ITargetable>(out var t))
        {
            t.GetDamage(Damage);
        }
    }

    public void setDamage(float damage)
    {
        this.Damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!listTag.Contains(collision.tag)) return;
        SendDamage(collision.gameObject, Damage);
        gameObject.SetActive(false);
        
    }

}

