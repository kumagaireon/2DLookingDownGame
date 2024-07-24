using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common.Data
{
    public class CharacterAttack : MonoBehaviour
    {
        // �U��
        [SerializeField] CharacterData character;
        [SerializeField] private GameObject currentObject;
        [Header("�G�����o����͈�")][SerializeField] private float detectionRange = 2f;
        [Header("�v���C���[����̋���")][SerializeField] private float followDistance = 1f;
        private GameObject Player;
        private int Damage;

        private void Start()
        {
            Damage = character.Damage;
            Player = GameObject.FindWithTag("Player"); // �v���C���[�I�u�W�F�N�g���擾
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
                    CharacterHp enmyHp = GetCurrentObject().GetComponent<CharacterHp>();
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