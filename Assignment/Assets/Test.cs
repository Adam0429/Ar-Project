
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test : MonoBehaviour 
{

    public CharacterController m_chara;
    public Transform m_point;
    public Image m_move;
    public Image m_rotate;
    public float m_moveSpeed;
    // Use this for initialization
    void Start ()
    {
        m_chara = GetComponent<CharacterController>();
        m_point = transform.GetChild(0);
    }
    public void Move()
    {
        Vector3 dis = new Vector3(m_chara.transform.position.x + m_move.transform.localPosition.x, m_chara.transform.position.y, m_chara.transform.position.z + m_move.transform.localPosition.y);
        Vector3 movement = dis * m_moveSpeed * Time.deltaTime;
        m_chara.Move(movement);
    }
	public void Rotate()
    {
        m_point.LookAt(new Vector3(m_point.position.x + m_rotate.transform.localPosition.x, m_point.position.y, m_point.position.z + m_rotate.transform.localPosition.y));
    }
}
