using UnityEngine;

namespace Common.Data
{
    public class CharacterMove2 : MonoBehaviour
    {
        //����

        [SerializeField] CharacterData character;
        float MoveSpeed;
        private void Start()
        {
            MoveSpeed = character.playerMoveSpeed;
        }

        private void Update()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            //���͈ړ�
            // ���͈ړ�
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            // �ړ��x�N�g���̌v�Z
            Vector2 moveVector = new Vector2(moveX, moveY) * MoveSpeed * Time.deltaTime;

            // �v���C���[�̈ʒu���X�V
            transform.Translate(moveVector);
        }
    }
}