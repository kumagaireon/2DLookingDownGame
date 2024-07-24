using UnityEngine;

namespace Common.Data
{
    public class CharacterAttack2 : MonoBehaviour
    {
        // �U��
        [SerializeField] CharacterData character;
        private GameObject currentObject;
        [Header("�G�����o����͈�")][SerializeField] private float detectionRange;
        [Header("�v���C���[����̋���")][SerializeField] private float followDistance;
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
                    // �����ɍU��������ǉ�
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
                mousePosition.z = 0; // 2D�Q�[���̏ꍇ�AZ���W��0�ɐݒ�

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