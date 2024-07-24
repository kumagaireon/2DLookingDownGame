using Common;
using InGame.Player;
using UnityEngine;
using UnityEngine.UI;

public class HPCount : MonoBehaviour
{
    [SerializeField] private Image HPImagePrefab; // HPImageのプレハブ
    [SerializeField] private PlayerHp playerHP;
    [SerializeField] private CharacterData hpData;
    [SerializeField] float IntervalX;
    public int maxHP{get; set; } // 最大HP
    private Image[] hpImages;

    private void Start()
    {
        HPGeneration();
    }

    // HPアイコンを生成するメソッド
    void HPGeneration()
    {
        maxHP = hpData.HP;
        hpImages = new Image[maxHP];

        for (int i = 0; i < maxHP; i++)
        {
            Image hpImage = Instantiate(HPImagePrefab, transform);
            hpImage.transform.localPosition = new Vector3(i * IntervalX, 0, 0); 
            hpImages[i] = hpImage;
        }

        playerHP.OnHPChanged += UpdateHP; // HPが変わったときに呼ばれるイベント
    }

    // HPが変わったときに呼ばれるメソッド
    void UpdateHP(int currentHP)
    {
        for (int i = 0; i < maxHP; i++)
        {
            // 現在のHPに応じてアイコンの表示/非表示を切り替える
            hpImages[i].gameObject.SetActive(i < currentHP);
        }
    }
}
