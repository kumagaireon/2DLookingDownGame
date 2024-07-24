using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InGame.Enemy
{
    public class EnemyMove2 : MonoBehaviour
    {
        private Transform player; // �v���C���[��Transform
        [SerializeField] CharacterData character;
        private float moveSpeed; // �ړ����x
        private void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            moveSpeed = character.EnemyMoveSpeed;
        }
        void Update()
        {
            MoveTowardsPlayerObject();
        }

        private void MoveTowardsPlayerObject()
        {
            // �v���C���[�̈ʒu���擾
            Vector3 playerPosition = player.position;

            // ���݂̈ʒu���擾
            Vector3 currentPosition = transform.position;

            // �v���C���[�̕������v�Z
            Vector3 direction = (playerPosition - currentPosition).normalized;

            // �v���C���[�̕����Ɉړ�
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}