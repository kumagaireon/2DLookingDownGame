using Common.Data.Character;
using TopDownGame.InGame;
using UnityEngine.InputSystem;

namespace InGame.Player
{
    /// <summary>
    /// �v���C���[�̍U���N���X�BCharacterAttack���p�����AInGameInputProvider.IPlayerActions�C���^�[�t�F�[�X������
    /// </summary>
    public class PlayerAttack : CharacterAttack, InGameInputProvider.IPlayerActions
    {
        private InGameInputProvider provider; // ���̓v���o�C�_�[

        // �I�u�W�F�N�g���L���ɂȂ����Ƃ��ɌĂяo�����
        void OnEnable()
        {
            provider = new InGameInputProvider(); // ���̓v���o�C�_�[�̃C���X�^���X���쐬
            provider.Player.SetCallbacks(this); // �R�[���o�b�N��ݒ�
            provider.Enable(); // ���̓v���o�C�_�[��L����
        }

        // �I�u�W�F�N�g�������ɂȂ����Ƃ��ɌĂяo�����
        void OnDisable()
        {
            provider.Disable(); // ���̓v���o�C�_�[�𖳌���
            provider.Dispose(); // ���̓v���o�C�_�[��j��
        }

        // �U�����͂��������Ƃ��ɌĂяo�����
        public void OnAttack(InputAction.CallbackContext context)
        {
            Attack(); // �U�����\�b�h���Ăяo��
        }

        public void OnMove(InputAction.CallbackContext context)
        {

        }

        // �U���\���ǂ����𔻒肷�郁�\�b�h
        protected override bool IsAttack()
        {
            // currentObject��null�łȂ��A���^�O��"Enemy"�ł���ꍇ�ɍU���\�Ƃ���
            return currentObject != null && currentObject.CompareTag("Enemy");
        }
    }
}