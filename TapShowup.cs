using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapShowup : MonoBehaviour
{
    public GameObject uiCanvas; // �A�N�e�B�u�ɂ���UI Canvas
    public Collider colliderToTap; // �^�b�v����R���C�_�[
    public string OpenPositionName;

    private bool canvasActive = false; // Canvas���A�N�e�B�u��Ԃ��ǂ���

    /*
     * �R���C�_�[���A�N�e�B�u���o���ĂȂ����炻��𒼂�
     */

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N���ꂽ�ꍇ
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // �J��������}�E�X���W�փ��C���΂�
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // ���C�������ɓ��������ꍇ
            {
                if (hit.collider == colliderToTap) // �w�肵���R���C�_�[�܂��͐V�����ݒ肵���R���C�_�[���^�b�v�����ꍇ
                {
                    canvasActive = !canvasActive; // Canvas�̃A�N�e�B�u��Ԃ𔽓]������
                    uiCanvas.SetActive(canvasActive); // Canvas�̃A�N�e�B�u��Ԃɍ��킹��UI���A�N�e�B�u���܂��͔�A�N�e�B�u������
                }
            }
        }
        
    }

    public void DeactivateCanvas()
    {
        uiCanvas.SetActive(false);
        canvasActive = false;
    }

    
    private void CameraMovement()
    {
        if (CameraManager.Instance != null || CameraManager1.Instance != null || CameraManager2.Instance != null || CameraManager3.Instance != null) // �ǂ��炩�� null �łȂ����Ƃ��m�F
        {
            if (CameraManager.Instance != null) // CameraManager �C���X�^���X�� null �łȂ��ꍇ
            {
                CameraManager.Instance.ChangeCameraPosition(OpenPositionName);
            }
            else if (CameraManager1.Instance != null)
            {
                CameraManager1.Instance.ChangeCameraPosition(OpenPositionName);
            }
            else if (CameraManager2.Instance != null)
            {
                CameraManager2.Instance.ChangeCameraPosition(OpenPositionName);
            }
            else
            {
                CameraManager3.Instance.ChangeCameraPosition(OpenPositionName);
            }
            colliderToTap.gameObject.SetActive(true);
        }
    }
}
