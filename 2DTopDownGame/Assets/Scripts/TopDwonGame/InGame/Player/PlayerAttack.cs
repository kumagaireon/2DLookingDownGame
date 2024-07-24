using InGame.Enemy;
using TopDownGame.InGame;
using UnityEngine.InputSystem;

namespace InGame.Player
{
    public class PlayerAttack : CharacterAttack, InGameInputProvider.IPlayerActions
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
            Attack();
        }

        public void OnMove(InputAction.CallbackContext context)
        {

        }

        protected override bool IsAttack()
        {
            return currentObject != null && currentObject.CompareTag("Enemy");
        }
    }

}