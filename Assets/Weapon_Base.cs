using Bang.Lib.ObjectPooling;
using UnityEngine;

public class Weapon_Base_Shoot : MonoBehaviour, IWeapon
{
    [SerializeField] GameObject Prefab_Bullet;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] float SpeedBullet = 20f;
    [SerializeField] float TimeBulletExist;
    public void Attack(GameObject target, float TotalDamage)
    {
        
        var bullet = Pool_Manager.Instance.GetFromPool(Prefab_Bullet.gameObject);

        var damagesend = bullet.GetComponent<ISendDamage>();

        var autoDisable = bullet.GetComponent<IAutoDisable>();

        damagesend.setDamage(TotalDamage);
        autoDisable.SetTimeExist(TimeBulletExist);

        bullet.transform.position = SpawnPoint.transform.position;

        
        Vector2 direction = target.transform.position - SpawnPoint.transform.position;

        
        var rb = bullet.gameObject.GetComponent<Rigidbody2D>();

        
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        rb.linearVelocity = direction.normalized * SpeedBullet;
       
    }
}

public interface IWeapon
{
    void Attack(GameObject target, float TotalDamage);
}