using System.Collections.Generic;
using UnityEngine;

public class BaseSendDamage2 : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] List<string> listTag = new List<string>();
    public void setDamage(float damage)
    {
        this.Damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!listTag.Contains(collision.tag)) return;
        if (collision.gameObject.TryGetComponent<ITargetable>(out var target))
        {
            target.GetDamage(Damage);
            
        }
    }

}

