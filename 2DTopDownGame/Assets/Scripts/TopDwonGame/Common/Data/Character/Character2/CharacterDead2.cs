using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common.Data
{
    public class CharacterDead2 : MonoBehaviour
    {
        [SerializeField] SoundController SoundController;

        public void Dead()
        {
            SoundController.Death();
            gameObject.SetActive(false);
        }
    }
}