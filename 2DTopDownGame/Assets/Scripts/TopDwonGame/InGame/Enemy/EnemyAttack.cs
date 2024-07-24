using Common.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace InGame.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        private Transform player; // プレイヤーのTransform
        [SerializeField] private float attackRange = 0.5f; // 攻撃範囲
        [SerializeField] private float retreatDistance = 1f; // 攻撃後に離れる距離
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
            // プレイヤーとの距離を計算
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // 距離が攻撃範囲内かどうかをチェック
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
        }

        private void AttackPlayer()
        {
            // 攻撃処理
            // プレイヤーのHPを減らす
            if (player.GetComponent<CharacterHp>() != null)
            {
                CharacterHp playerHp = player.GetComponent<CharacterHp>();
                if (playerHp != null)
                {
                    playerHp.TakeDamage(damage);
                    RetreatFromPlayer();
                }
            }
        }

        private void RetreatFromPlayer()
        {
            // プレイヤーから離れる処理
            Vector3 direction = (transform.position - player.position).normalized;
            Vector3 retreatPosition = transform.position + direction * retreatDistance;
            transform.position = retreatPosition;
        }
    }
}