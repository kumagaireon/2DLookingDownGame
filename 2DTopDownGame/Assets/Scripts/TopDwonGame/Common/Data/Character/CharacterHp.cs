using UnityEngine;

public class CharacterHp : MonoBehaviour
{
    public int currentHP { get; set; }
    public int maxHP { get; set; }
    public delegate void HPChanged(int currentHP);
    public event HPChanged OnHPChanged;

    public CharacterDead characterDead { get; set; }
    private void Start()
    {
        currentHP = maxHP;
    }
    public virtual void HP(int damage,GameObject target)
    {
        currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);
        OnHPChanged?.Invoke(currentHP);
        if (currentHP <= 0)
        {
            characterDead.Dead(target);
        }
    }
}