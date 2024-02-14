using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteManager : MonoBehaviour
{
    public float turnSpeed = 5f;

    public float deathAnimationSpeed = 2f;

    public Sprite spriteCharacter = null;
    
    public Sprite spriteMaskedCharacter = null;

    private SpriteRenderer spriteRenderer = null;

    private Quaternion m_Rotation = Quaternion.Euler(0, 0, 0);

    private Quaternion m_DeadRotation = Quaternion.Euler(0, 0, 90);

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
            transform.rotation = Quaternion.Lerp(transform.rotation, m_Rotation * m_DeadRotation, Time.deltaTime * deathAnimationSpeed);
            return;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, m_Rotation, Time.deltaTime * turnSpeed);

        if(spriteRenderer != null)
        {
            float posY = transform.position.y;

            if(posY >= 0)
            {
                if(spriteCharacter != null) 
                    spriteRenderer.sprite = spriteCharacter;
            }else
            {
                if(spriteMaskedCharacter != null)
                    spriteRenderer.sprite = spriteMaskedCharacter;
            }
        }
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
