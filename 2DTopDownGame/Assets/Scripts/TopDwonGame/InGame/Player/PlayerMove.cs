using TopDownGame.InGame;
using UnityEngine;
using UnityEngine.InputSystem;


namespace InGame.Player
{
    public class PlayerMove : CharacterMove, InGameInputProvider.IPlayerActions
    {
        private InGameInputProvider provider;

        void OnEnable()
        {
            provider = new InGameInputProvider();
            provider.Player.SetCallbacks(this);
            provider.Enable();
        }

        void OnDisable()
        {
            provider.Disable();
            provider.Dispose();
        }
        public void OnAttack(InputAction.CallbackContext context)
        {
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            direction = context.ReadValue<Vector2>();
        }
    }
}