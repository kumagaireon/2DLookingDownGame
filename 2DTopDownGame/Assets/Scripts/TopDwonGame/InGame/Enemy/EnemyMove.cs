using Common.Data.Character;
using UnityEngine;

namespace InGame.Enemy
{
    /// <summary>
    /// �G�̈ړ����Ǘ�����N���X�BCharacterMove���p��
    /// </summary>
    public class EnemyMove : CharacterMove
    {
        [SerializeField] CharacterBase player;
        // �ړ����\�b�h���I�[�o�[���C�h
        public override void Move()
        {
            UpdateDirection(); // �ړ��������X�V
            base.Move(); // �e�N���X��Move���\�b�h���Ăяo��
        }

        // �ړ��������X�V���郁�\�b�h
        void UpdateDirection()
        {
            // �v���C���[�̈ʒu���擾
            Vector2 playerPosition = player.transform.position;

            // ���݂̈ʒu���擾
            Vector2 currentPosition = transform.position;

            // �v���C���[�̕������v�Z���A���K�����ĕ����x�N�g����ݒ�
            direction = (playerPosition - currentPosition).normalized;
        }
    }
}