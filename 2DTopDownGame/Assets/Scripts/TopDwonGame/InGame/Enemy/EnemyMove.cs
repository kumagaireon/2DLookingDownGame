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
            // プレイヤーの位置を取得
            Vector2 playerPosition = player.transform.position;

            // 現在の位置を取得
            Vector2 currentPosition = transform.position;

            // プレイヤーの方向を計算
            direction = (playerPosition - currentPosition).normalized;

        }
    }
}