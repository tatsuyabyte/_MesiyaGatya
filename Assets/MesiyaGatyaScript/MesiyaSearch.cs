using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesiyaSearch : MonoBehaviour
{
    public Dictionary<int, MesiyaShop> m_shopData;

    [SerializeField]public List<MesiyaShop> m_shopViewer;

    public List<MesiyaShop> GetShopDataAll()
    {
        var count = m_shopData.Count;
        var list = new List<MesiyaShop>();
        for(int i = 0; i < count; i++)
        {
            list.Add(m_shopData[i]);
        }
        return list;
    }

    public MesiyaShop GetShopData(int instanceID)
    {
        return m_shopData[instanceID];
    }

    private void Start()
    {
        m_shopData = new Dictionary<int,MesiyaShop>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!m_shopData.ContainsKey(collision.gameObject.GetInstanceID()))
        {
            m_shopData.Add(collision.gameObject.GetInstanceID(), collision.gameObject.GetComponent<MesiyaShop>());
            m_shopViewer.Add(collision.gameObject.GetComponent<MesiyaShop>());
        }
    }
}
