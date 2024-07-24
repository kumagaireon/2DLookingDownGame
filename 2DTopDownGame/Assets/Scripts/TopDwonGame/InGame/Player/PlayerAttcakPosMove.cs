using UnityEngine;

namespace InGame.Player
{
    /// <summary>
    /// �v���C���[�̍U���ʒu���}�E�X�ɒǏ]������N���X
    /// </summary>
    public class PlayerAttcakPosMove : MonoBehaviour
    {
        [SerializeField] private GameObject Player;
        [Header("�v���C���[����̋���")][SerializeField] private float followDistance;
      
        // �Œ�X�V���\�b�h�B�������Z�̍X�V�^�C�~���O�ŌĂяo�����
        private void FixedUpdate()
        {
            FollowMouse(); // �}�E�X�ɒǏ]���鏈�����Ăяo��
        }

        // �}�E�X�̈ʒu�ɒǏ]���郁�\�b�h
        void FollowMouse()
        {
            if (Player != null)
            {
                // �}�E�X�̃��[���h���W���擾
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // z���W��0�ɐݒ�

                // �v���C���[����}�E�X�ւ̕������v�Z���A���K��
                Vector3 direction = (mousePosition - Player.transform.position).normalized;
                // �v���C���[����w�肳�ꂽ�����������ꂽ�ʒu���v�Z
                Vector3 targetPosition = Player.transform.position + direction * followDistance;

                // �I�u�W�F�N�g�̈ʒu���X�V
                transform.position = targetPosition;
            }
        }
    }
}