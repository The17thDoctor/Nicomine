using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    public MapGenerator mapGenerator;

    private CharacterMovement characterMovement = null;


    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMiningButtonClicked()
    {
        if(mapGenerator != null && characterMovement != null)
        {
            Debug.Log("aze");
            float posX = transform.position.x;
            float posY = transform.position.y;

            CharacterMovement.JoystickFacingDirection joystickFacingDirection = CharacterMovement.JoystickFacingDirection.None;
            bool isPlayerFacingLeft = false;
            if (characterMovement != null)
            {
                isPlayerFacingLeft = characterMovement.IsPlayerFacingLeft();
                joystickFacingDirection = characterMovement.GetJoystickFacingDirection();
            }

            int targetX = Mathf.RoundToInt(posX);
            int targetY = Mathf.RoundToInt(posY);

            switch (joystickFacingDirection)
            {
                case CharacterMovement.JoystickFacingDirection.Up:
                    targetX = Mathf.RoundToInt(posX);
                    targetY = Mathf.CeilToInt(posY) + 1;
                    break;
                case CharacterMovement.JoystickFacingDirection.Down:
                    targetX = Mathf.RoundToInt(posX);
                    targetY = Mathf.FloorToInt(posY) - 1;
                    break;
                case CharacterMovement.JoystickFacingDirection.Left:
                    targetX += -1;
                    break;
                case CharacterMovement.JoystickFacingDirection.Right:
                    targetX += 2;
                    break;
                case CharacterMovement.JoystickFacingDirection.None:
                    int targetDir = isPlayerFacingLeft ? -1 : 1;
                    targetX += targetDir;
                    break;
            }

            Debug.Log("x: " + targetX + "  y: " + targetY);
            mapGenerator.MineBlock(targetX, targetY);
        }
    }
}
