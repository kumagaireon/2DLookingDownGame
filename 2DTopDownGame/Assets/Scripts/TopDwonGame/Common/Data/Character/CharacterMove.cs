using UnityEngine;
namespace Common.Data.Character
{
    /// <summary>
    /// �L�����N�^�[�̈ړ��𐧌䂷�钊�ۃN���X
    /// </summary>
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
}