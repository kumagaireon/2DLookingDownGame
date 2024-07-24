using Common.Data.Character;
using TopDownGame.InGame;
using UnityEngine;
using UnityEngine.InputSystem;


namespace InGame.Player
{
    /// <summary>
    /// �v���C���[�̈ړ����Ǘ�����N���X�BCharacterMove���p�����AInGameInputProvider.IPlayerActions�C���^�[�t�F�[�X������
    /// </summary>
    public class PlayerMove : CharacterMove, InGameInputProvider.IPlayerActions
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

        // �U�����͂��������Ƃ��ɌĂяo�����i���݂͖������j
        public void OnAttack(InputAction.CallbackContext context)
        {
        }

        // �ړ����͂��������Ƃ��ɌĂяo�����
        public void OnMove(InputAction.CallbackContext context)
        {
            // ���͂��ꂽ�ړ��������擾���Adirection�t�B�[���h�ɐݒ�
            direction = context.ReadValue<Vector2>();
        }
    }
}