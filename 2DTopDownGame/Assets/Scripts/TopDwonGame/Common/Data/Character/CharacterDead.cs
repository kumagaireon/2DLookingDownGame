using UnityEngine;

public abstract class CharacterDead : MonoBehaviour
{
    public SoundController SoundController { get; set; }
    public void Dead(GameObject target)
    {
        SoundController.Death();
        target.gameObject.SetActive(false);
    }
}