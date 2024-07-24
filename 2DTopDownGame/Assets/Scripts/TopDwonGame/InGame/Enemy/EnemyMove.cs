using UnityEngine;
namespace InGame.Enemy
{
    public class EnemyMove : CharacterMove
    {
        [SerializeField] CharacterBase player;
        public override void Move()
        {
            UpdateDirection();
            base.Move();
        }

        void UpdateDirection()
        {
            // �v���C���[�̈ʒu���擾
            Vector2 playerPosition = player.transform.position;

            // ���݂̈ʒu���擾
            Vector2 currentPosition = transform.position;

            // �v���C���[�̕������v�Z
            direction = (playerPosition - currentPosition).normalized;

        }
    }
}