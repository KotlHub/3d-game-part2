using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RadarScript : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private GameObject character;
    private Image pointer;
    // Start is called before the first frame update
    void Start()
    {
        pointer = GameObject.Find("RadarPointer").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toCoin = coin.transform.position - character.transform.position;
        toCoin.y = 0;  // ������� - ���������� ������� �� ���� �������
                       // ������ �� ���� �������� ��� � ����������� ������
                       // character.transform.forward ����������� �������������� � CharacterScript
        
           float angle = Vector3.SignedAngle(
            character.transform.forward,
            toCoin,
            Vector3.up) * Mathf.Deg2Rad;
        float range = toCoin.magnitude;
        if(range < 30)
        {
            pointer.gameObject.SetActive(false);
        }
        else
        {
            pointer.gameObject.SetActive(true);
            pointer.rectTransform.localPosition = new Vector3(
                range * Mathf.Sin(angle),
                range * Mathf.Cos(angle),
                0);
        }
    }
}
