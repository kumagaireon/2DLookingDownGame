using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Common.Data
{
    public class CharacteMove : MonoBehaviour
    {
        //動き

        [SerializeField] CharacterData character;
        float MoveSpeed;
        private void Start()
        {
            MoveSpeed = character.MoveSpeed * 1.5f;
        }

        private void Update()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            //入力移動
            // 入力移動
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            // 移動ベクトルの計算
            Vector2 moveVector = new Vector2(moveX, moveY) * MoveSpeed * Time.deltaTime;

            // プレイヤーの位置を更新
            transform.Translate(moveVector);
        }
    }
}