using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteManager : MonoBehaviour
{
    public float turnSpeed = 5f;

    private SpriteRenderer spriteRenderer = null;

    private Quaternion m_Rotation = Quaternion.Euler(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, m_Rotation, Time.deltaTime * turnSpeed);
    }

    public void ChooseFacingDirection(bool lookingLeft)
    {
        if (spriteRenderer != null)
        {
            if (lookingLeft)
            {
                m_Rotation = Quaternion.Euler(0, 180, 0);
            }else
            {
                m_Rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
