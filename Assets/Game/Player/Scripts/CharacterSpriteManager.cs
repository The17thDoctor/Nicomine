using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteManager : MonoBehaviour
{
    public float turnSpeed = 5f;

    public float deathAnimationSpeed = 1f;

    private SpriteRenderer spriteRenderer = null;

    private Quaternion m_Rotation = Quaternion.Euler(0, 0, 0);

    private Quaternion m_DeadRotation = Quaternion.Euler(-35, 0, 90);

    public bool isPlayerDead = false; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, m_DeadRotation * m_Rotation, Time.deltaTime * deathAnimationSpeed);
            return;
        }

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

    public void playDeathAnimation()
    {
        isPlayerDead = true;
    }
}
