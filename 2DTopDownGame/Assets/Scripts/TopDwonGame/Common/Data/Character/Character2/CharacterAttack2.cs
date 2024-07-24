using UnityEngine;

namespace Common.Data
{
    public class CharacterAttack2 : MonoBehaviour
    {
        // 攻撃
        [SerializeField] CharacterData character;
        private GameObject currentObject;
        [Header("敵を検出する範囲")][SerializeField] private float detectionRange;
        [Header("プレイヤーからの距離")][SerializeField] private float followDistance;
        private GameObject Player;
        private int Damage;

        private void Start()
        {
            Damage = character.Damage;
            Player = transform.parent.gameObject;
        }

        private void Update()
        {
            Attack();
            FollowMouse();
        }

        void Attack()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (GetCurrentObject() != null && GetCurrentObject().CompareTag("Enemy"))
                {
                    // ここに攻撃処理を追加
                    CharacterHp2 enmyHp = GetCurrentObject().GetComponent<CharacterHp2>();
                    if (enmyHp != null)
                    {
                        enmyHp.TakeDamage(Damage);
                        if (enmyHp.currentHP == 0)
                        {
                            TimeAndKill.IncrementEnemyKill();
                        }
                        currentObject = null;
                    }
                }
            }
        }

        void FollowMouse()
        {
            if (Player != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // 2Dゲームの場合、Z座標を0に設定

                Vector3 direction = (mousePosition - Player.transform.position).normalized;
                Vector3 targetPosition = Player.transform.position + direction * followDistance;

                transform.position = targetPosition;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            currentObject = collision.gameObject;
        }

        public GameObject GetCurrentObject()
        {
            return currentObject;
        }
    }
}