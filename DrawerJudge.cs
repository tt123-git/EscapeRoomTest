using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerJudge : MonoBehaviour
{
    private bool _IsOpen = false;

    public TapObjectChange[] TapChanges;
    public int[] AnswerIndexes;
    public GameObject OpenCollider;

    void Update()
    {
        if (_IsOpen) return;

        bool isCorrect = CheckAnswer();
        if (isCorrect)
        {
            _IsOpen = true;
            foreach (var TapChange in TapChanges)
            {
                TapChange.enabled = false;
                TapChange.gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            ActivateOpenCollider();
        }
    }

    private bool CheckAnswer()
    {
        if (TapChanges.Length != AnswerIndexes.Length)
        {
            return false;
        }

        for (int i = 0; i < TapChanges.Length; i++)
        {
            if (TapChanges[i].Index != AnswerIndexes[i])
                return false;
        }

        return true;
    }

    private void ActivateOpenCollider()
    {
        OpenCollider.SetActive(true);
    }
}
