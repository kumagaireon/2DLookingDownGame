using Common.Data.Character;
using TopDownGame.InGame;
using UnityEngine;
using UnityEngine.InputSystem;


namespace InGame.Player
{
    /// <summary>
    /// プレイヤーの移動を管理するクラス。CharacterMoveを継承し、InGameInputProvider.IPlayerActionsインターフェースを実装
    /// </summary>
    public class PlayerMove : CharacterMove, InGameInputProvider.IPlayerActions
    {
        private InGameInputProvider provider; // 入力プロバイダー

        // オブジェクトが有効になったときに呼び出される
        void OnEnable()
        {
            provider = new InGameInputProvider(); // 入力プロバイダーのインスタンスを作成
            provider.Player.SetCallbacks(this); // コールバックを設定
            provider.Enable(); // 入力プロバイダーを有効化
        }

        // オブジェクトが無効になったときに呼び出される
        void OnDisable()
        {
            provider.Disable(); // 入力プロバイダーを無効化
            provider.Dispose(); // 入力プロバイダーを破棄
        }

        // 攻撃入力があったときに呼び出される（現在は未実装）
        public void OnAttack(InputAction.CallbackContext context)
        {
        }

        // 移動入力があったときに呼び出される
        public void OnMove(InputAction.CallbackContext context)
        {
            // 入力された移動方向を取得し、directionフィールドに設定
            direction = context.ReadValue<Vector2>();
        }
    }
}