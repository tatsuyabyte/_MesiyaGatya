using System.Collections;
using UnityEngine;
using UnityEngine.Networking;// Unity���Ńl�b�g���[�N���g�p����Ƃ��ɋL������

public class StaticMapController : MonoBehaviour
{
    private const string STATIC_MAP_URL = "https://maps.googleapis.com/maps/api/staticmap?key=${Places}&zoom=15&size=640x640&scale=2&maptype=terrain&style=element:labels|visibility:off";// Google Maps Static API URL�A${APIKey}���쐬����api�L�[�ɏ���������
    private int frame = 0;// �}�b�v�̍X�V������Ԋu�̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getStaticMap());// getStaticMap�����s����
    }

    // Update is called once per frame
    void Update()
    {
        frame++;// frame��1���ς���

        if (frame >= 300)// �����Aframe��300�ȏ�Ȃ�A
        {
            StartCoroutine(getStaticMap());// getStaticMap�����s����
            frame = 0;// frame��0�ɂ���
        }
    }

    IEnumerator getStaticMap()
    {
        var query = "";// query������������
        query += "&center=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));// center�Ŏ擾����~�j�}�b�v�̒������W��ݒ�
        query += "&markers=" + UnityWebRequest.UnEscapeURL(string.Format("{0},{1}", Input.location.lastData.latitude, Input.location.lastData.longitude));// markers�œn�������W(=���݈ʒu)�Ƀ}�[�J�[�𗧂Ă�
        var req = UnityWebRequestTexture.GetTexture(STATIC_MAP_URL + query);// ���N�G�X�g�̒�`
        yield return req.SendWebRequest();// ���N�G�X�g���s

        if (req.error == null)// �����A���N�G�X�g���G���[�łȂ���΁A
        {
            Destroy(GetComponent<Renderer>().material.mainTexture); //�}�b�v���Ȃ���
            GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)req.downloadHandler).texture; //�}�b�v��\�����
        }
    }
}