using Common;
using Common.Data;
using UnityEngine;

namespace InGame.Enemy
{
    public class EnemyAttack2 : MonoBehaviour
    {
        private Transform player; // �v���C���[��Transform
        [SerializeField] private float attackRange = 0.5f; // �U���͈�
        [SerializeField] private float retreatDistance = 1f; // �U����ɗ���鋗��
        int damage;
        [SerializeField] CharacterData character;

        private void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            damage = character.Damage;
        }

        void Update()
        {
            CheckAttackRange();
        }

        private void CheckAttackRange()
        {
            // �v���C���[�Ƃ̋������v�Z
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // �������U���͈͓����ǂ������`�F�b�N
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
        }

        private void AttackPlayer()
        {
            // �U������
            // �v���C���[��HP�����炷
            if (player.GetComponent<CharacterHp2>() != null)
            {
                CharacterHp2 playerHp = player.GetComponent<CharacterHp2>();
                if (playerHp != null)
                {
                    playerHp.TakeDamage(damage);
                    RetreatFromPlayer();
                }
            }
        }

        private void RetreatFromPlayer()
        {
            // �v���C���[���痣��鏈��
            Vector3 direction = (transform.position - player.position).normalized;
            Vector3 retreatPosition = transform.position + direction * retreatDistance;
            transform.position = retreatPosition;
        }
    }
}