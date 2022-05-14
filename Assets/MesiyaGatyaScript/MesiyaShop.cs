using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesiyaShop : MonoBehaviour
{
    [SerializeField]
    private float m_calorie = 0;

    public float calorie
    {
        get
        {
            return m_calorie;
        }
    }
}
