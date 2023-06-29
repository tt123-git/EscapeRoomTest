using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapObjectMove : MonoBehaviour
{
    public Vector3 MovedPosition;

    // �I�u�W�F�N�g���ړ������ǂ�����\���t���O
    private bool isMoving = false;

    private void Update()
    {
        // �I�u�W�F�N�g���ړ����łȂ���΁A�^�b�v���ꂽ��ړ�����
        if (!isMoving && Input.GetMouseButtonUp(0))
        {
            // �^�b�v���ꂽ�ʒu����Ray���΂�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Ray���^�b�v���ꂽ�I�u�W�F�N�g�ɓ��������ꍇ�A�I�u�W�F�N�g���ړ�����
                if (hit.collider.gameObject == gameObject)
                {
                    // �I�u�W�F�N�g���ړ��J�n
                    isMoving = true;
                    gameObject.transform.position = MovedPosition;
                }
            }
        }
    }
}