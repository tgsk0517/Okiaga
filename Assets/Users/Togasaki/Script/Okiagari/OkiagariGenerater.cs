using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkiagariGenerater : SingletonMonoBehaviour<OkiagariGenerater>
{
    [SerializeField, Header("�����I�u�W�F�N�g")]
    private GameObject okiagariObj;

    /// <summary>
    /// �X�^�[�g
    /// </summary>
    public Transform startPos;

    /// <summary>
    /// ��ʒu
    /// </summary>
    public Transform homePos;

    /// <summary>
    /// �I��
    /// </summary>
    public Transform endPos;

    /// <summary>
    /// ��������
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// ���݂̋N���オ��I�u�W�F�N�g
    /// </summary>
    private GameObject okiagariRef;

    /// <summary>
    /// �N���オ��𐶐�
    /// </summary>
    public void GenerateOkiagari()
    {
        okiagariRef = Instantiate(okiagariObj, startPos.position, Quaternion.identity);
        okiagariRef.GetComponent<Okiagari>().MoveToHome().Forget();
    }

    /// <summary>
    /// �N���オ�������
    /// </summary>
    public void DestroyOkiagari()
    {
        okiagariRef.GetComponent<Okiagari>().MoveToEnd().Forget();
    }

}
