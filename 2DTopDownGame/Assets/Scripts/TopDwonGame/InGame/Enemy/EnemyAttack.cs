using UnityEngine;

namespace InGame.Enemy
{
    public class EnemyAttack : CharacterAttack
    {
        [SerializeField] CharacterBase player;
        [SerializeField] private float retreatDistance; // �U����ɗ���鋗��

        public override void Attack()
        {
            base.Attack();
            RetreatFromPlayer();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            currentObject = collision.gameObject;
            if (IsAttack())
                Attack();
        }

        private void RetreatFromPlayer()
        {
            // �v���C���[���痣��鏈��
            Vector3 direction = (transform.position - player.transform.position).normalized;
            Vector3 retreatPosition = transform.position + direction * retreatDistance;
            transform.position = retreatPosition;
        }
        protected override bool IsAttack()
        {
            return currentObject != null && currentObject.CompareTag("Player");
        }

    }
}