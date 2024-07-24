using Common.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HPCount : MonoBehaviour
{
    public Image HPImagePrefab; // HPImage�̃v���n�u
    public int maxHP; // �ő�HP
    private Image[] hpImages;
    private CharacterHp characterHp;
    public float IntervalX;

    private void Start()
    {
        HPGeneration();
    }

    void HPGeneration()
    {
        characterHp = GameObject.FindWithTag("Player").GetComponent<CharacterHp>();
        maxHP = characterHp.maxHP;
        hpImages = new Image[maxHP];

        for (int i = 0; i < maxHP; i++)
        {
            Image hpImage = Instantiate(HPImagePrefab, transform);
            hpImage.transform.localPosition = new Vector3(i * IntervalX, 0, 0); // 30�͊Ԋu�̗�
            hpImages[i] = hpImage;
        }

        characterHp.OnHPChanged += UpdateHP; // HP���ς�����Ƃ��ɌĂ΂��C�x���g
    }

    void UpdateHP(int currentHP)
    {
        for (int i = 0; i < maxHP; i++)
        {
            hpImages[i].gameObject.SetActive(i < currentHP);
        }
    }
}
