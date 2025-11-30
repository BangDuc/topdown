using Bang.Lib.ObjectPooling;
using UnityEngine;

public class Weapon_Base_Mele : MonoBehaviour, IWeapon
{
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] float attackRadius;
    [SerializeField] GameObject Prefab;
    [SerializeField] float TimeExist;

    public void Attack(GameObject target, float TotalDamage)
    {
        var split = Pool_Manager.Instance.GetFromPool(Prefab);
            
        split.GetComponent<IAutoDisable>().SetTimeExist(TimeExist);
        split.GetComponent<ISendDamage>().setDamage(TotalDamage);

        // Tính toán hướng
        Vector2 directionToEnemy = target.transform.position - Player_Manager.Instance.Player.transform.position;
        Vector2 normalizedDirection = directionToEnemy.normalized;

        Vector2 PlayerPoint = Player_Manager.Instance.Player.transform.position;
        Vector2 spawnPosition = PlayerPoint + (normalizedDirection * attackRadius);

        
        float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

      
        split.transform.position = spawnPosition;
        split.transform.rotation = rotation;

       
        Vector3 localScale = Vector3.one; 

        
        if (directionToEnemy.x < 0)
        {
           
            localScale.y = -1;
        }

        split.transform.localScale = localScale;
        

       
        split.transform.SetParent(SpawnPoint.transform, true);
    }
}