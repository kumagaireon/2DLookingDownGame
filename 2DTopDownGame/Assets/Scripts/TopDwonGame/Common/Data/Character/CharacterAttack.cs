using UnityEngine;

public abstract class CharacterAttack : MonoBehaviour
{
    public int damage { get; set; }
    protected GameObject currentObject;

    public virtual void Attack()
    {
        if (IsAttack())
        {
            CharacterHp hp = currentObject.GetComponent<CharacterHp>();
            hp.HP(damage, currentObject);
            currentObject = null;
        }
    }

    protected abstract bool IsAttack();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentObject = collision.gameObject;
    }
}
