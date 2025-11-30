using UnityEngine;

public class Health_Base : MonoBehaviour,IResetComponent
{
    [SerializeField]float maxHP=100f;
    [SerializeField]float currentHP=100f;
    [SerializeField]bool isDead=false;
    public float MaxHP { get => maxHP; set => maxHP = value; }
    public float CurrentHP { get => currentHP; set => currentHP = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    public void DeductHP(float damage)
    {
        if (isDead) return;
        if (damage <= 0) return;
        currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);
        if (currentHP <= 0)
        {
            IsDead = true;
        }
    }

    public void HealHP(float HpHeal)
    {
        if (isDead) return;
        if (HpHeal <= 0) return;
        currentHP = Mathf.Clamp(HpHeal + HpHeal, 0, maxHP);
    }
    public void ResetObject()
    {
        maxHP = 100f;
        currentHP = 100f;
        isDead = false;
    }
}
