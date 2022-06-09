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

    [SerializeField, Header("�m�[�c")]
    private GameObject notes;


    /// <summary>
    /// �~�X�������̏���
    /// HP�����炵�A�m�[�c������
    /// </summary>
    public void EnterNotification()
    {
        
    }

    public void MissNotification()
    {
        //HP�����炷����
        NotesManager.Instance.bar.TakeDamage();

        //�m�[�c����������
        StartCoroutine("MissPerformance");

    }

    /// <summary>
    /// �~�X�������A�m�[�c�̐F��ς��ăm�[�c������
    /// </summary>
    IEnumerator MissPerformance()
    {
        notes.GetComponent<Notes>().tokenSource.Cancel();
        notes.GetComponent<Notes>().isFailed = true;
        meshRenderer.material.color = missColor;
        NotesManager.Instance.missNum++;

        yield return new WaitForSeconds(0.5f);

        Destroy(transform.parent.gameObject);

        yield break;
    }

}
