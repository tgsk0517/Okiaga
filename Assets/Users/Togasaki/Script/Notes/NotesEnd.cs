using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesEnd : MonoBehaviour, INotes
{
    [SerializeField, Header("�F�ύX�p���b�V�������_���[�Q��")]
    private MeshRenderer meshRenderer;

    [SerializeField, Header("�~�X���F")]
    private Color missColor;

    [SerializeField, Header("�f�B���C")]
    private float delayTime;

    /// <summary>
    /// �~�X�������̏���
    /// HP�����炵�A�m�[�c������
    /// </summary>
    public void EnterNotification()
    {
        //HP�����炷����

        //�m�[�c����������
        StartCoroutine("MissPerformance");
    }

    /// <summary>
    /// �~�X�������A�m�[�c�̐F��ς��ăm�[�c������
    /// </summary>
    IEnumerator MissPerformance()
    {
        meshRenderer.material.color = missColor;

        yield return new WaitForSeconds(delayTime);
        
        Destroy(transform.parent.gameObject);

        yield break;
    }

}
