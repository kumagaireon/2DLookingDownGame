using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InGame.Enemy
{
    public class EnemyMove2 : MonoBehaviour
    {
        private Transform player; // プレイヤーのTransform
        [SerializeField] CharacterData character;
        private float moveSpeed; // 移動速度
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
            // プレイヤーの位置を取得
            Vector3 playerPosition = player.position;

            // 現在の位置を取得
            Vector3 currentPosition = transform.position;

            // プレイヤーの方向を計算
            Vector3 direction = (playerPosition - currentPosition).normalized;

            // プレイヤーの方向に移動
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}