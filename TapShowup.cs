using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapShowup : MonoBehaviour
{
    public GameObject uiCanvas; // �A�N�e�B�u�ɂ���UI Canvas
    public Collider colliderToTap; // �^�b�v����R���C�_�[

    private float lastTapTime; // �O��^�b�v��������
    private float tapDelay = 0.2f; // �^�b�v�Ƃ��ĔF�����鎞�ԊԊu

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N���ꂽ�ꍇ
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // �J��������}�E�X���W�փ��C���΂�
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // ���C�������ɓ��������ꍇ
            {
                if (hit.collider == colliderToTap) // �w�肵���R���C�_�[���^�b�v�����ꍇ
                {
                    if (Time.time - lastTapTime < tapDelay) // �O��^�b�v���Ă���̎��Ԃ����ȉ��ł����
                    {
                        if (uiCanvas.activeSelf == true) // UI���A�N�e�B�u��Ԃ̏ꍇ
                        {
                            uiCanvas.SetActive(false); // UI���A�N�e�B�u�ɂ���
                        }
                    }
                    else
                    {
                        if (uiCanvas.activeSelf == false) // UI����A�N�e�B�u��Ԃ̏ꍇ
                        {
                            uiCanvas.SetActive(true); // UI���A�N�e�B�u�ɂ���
                        }
                    }
                    lastTapTime = Time.time; // �O��^�b�v�������Ԃ��X�V����
                }
            }
        }
    }
}
