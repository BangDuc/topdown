using UnityEngine;

public class BaseGetDamage : MonoBehaviour, ITargetable
{
    Health_Base health;
    public void GetDamage(float damage)
    {
        if (damage <= 0) return;
        health.DeductHP(damage);
    }
    private void Start()
    {
        health =GetComponent<Health_Base>();
    }
}
public interface ITargetable
{
    void GetDamage(float damage);
}
