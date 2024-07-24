using UnityEngine;

public abstract class CharacterMove : MonoBehaviour
{
   [SerializeField] protected new Rigidbody2D rigidbody;
    protected Vector2 direction;
    public float MoveSpeed { get; set; }

    public virtual void Move()
    {
        rigidbody.velocity = direction * MoveSpeed;
    }
}
