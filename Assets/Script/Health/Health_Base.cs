using UnityEngine;

public class Health_Base : MonoBehaviour
{
    [SerializeField]float MaxHP;
    [SerializeField]float currentHP;

    public void DeductHP(float damage)
    {
        if (damage <= 0) return;
        currentHP = Mathf.Clamp(currentHP - damage, 0, MaxHP);
    }
    public void HealHP(float HpHeal)
    {
        if (HpHeal <= 0) return;
        currentHP = Mathf.Clamp(HpHeal + HpHeal, 0, MaxHP);
    }
}
