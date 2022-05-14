using System;
using UnityEngine;
using UnityEngine.UI;
 
public class ShowGPS : MonoBehaviour
{
    public GameObject LatitudeText = null;// �ܓx��\�����邽�߂̕���
    public GameObject LongitudeText = null;// �o�x��\�����邽�߂̕���

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();// GPS�@�\�̗��p�J�n
    }

    // Update is called once per frame
    void Update()
    {
        Text latitude_component = LatitudeText.GetComponent<Text>();// �R�Â���LatitudeText�̃I�u�W�F�N�g��ϐ��Ɋi�[
        Text longitude_component = LongitudeText.GetComponent<Text>();// �R�Â���LongitudeText�̃I�u�W�F�N�g��ϐ��Ɋi�[
        latitude_component.text = Convert.ToString(Input.location.lastData.latitude);// Text�I�u�W�F�N�g��text�������擾����GPS���̈ܓx�ŏ㏑��
        longitude_component.text = Convert.ToString(Input.location.lastData.longitude);// Text�I�u�W�F�N�g��text�������擾����GPS���̌o�x�ŏ㏑��
    }
}