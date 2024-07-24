using Common.Data.Character;
using UnityEngine;

namespace InGame.Enemy
{
    /// <summary>
    /// �G�̍U�����Ǘ�����N���X�BCharacterAttack���p��
    /// </summary>
    public class EnemyAttack : CharacterAttack
    {
        [SerializeField] CharacterBase player;
        [SerializeField] private float retreatDistance; // �U����ɗ���鋗��

        // �U�����\�b�h���I�[�o�[���C�h
        public override void Attack()
        {
            base.Attack(); // �e�N���X��Attack���\�b�h���Ăяo��
            RetreatFromPlayer(); // �U����Ƀv���C���[���痣���
        }

        // �g���K�[���ɃI�u�W�F�N�g�����݂���ԂɌĂяo�����
        private void OnTriggerStay2D(Collider2D collision)
        {
            currentObject = collision.gameObject; // ���݂̃I�u�W�F�N�g��ݒ�
            if (IsAttack()) // �U���\���ǂ������`�F�b�N
                Attack(); // �U�����\�b�h���Ăяo��
        }

        // �v���C���[���痣��鏈��
        private void RetreatFromPlayer()
        {
            // �v���C���[���痣���������v�Z
            Vector3 direction = (transform.position - player.transform.position).normalized;
            // �����ʒu���v�Z
            Vector3 retreatPosition = transform.position + direction * retreatDistance;
            // �V�����ʒu�Ɉړ�
            transform.position = retreatPosition;
        }

        // �U���\���ǂ����𔻒肷�郁�\�b�h
        protected override bool IsAttack()
        {
            // currentObject��null�łȂ��A���^�O��"Player"�ł���ꍇ�ɍU���\�Ƃ���
            return currentObject != null && currentObject.CompareTag("Player");
        }
    }
}