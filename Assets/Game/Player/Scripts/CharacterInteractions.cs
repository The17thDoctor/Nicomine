using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractions : MonoBehaviour
{
    public MapGenerator mapGenerator;

    private CharacterMovement characterMovement = null;

    public MiningButton miningButton = null;

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    void FixedUpdate()
    {
        if(miningButton != null && miningButton.isButtonPressed)
        {
            onMiningButtonClicked();
            miningButton.timePressed += Time.fixedDeltaTime;
        }
    }

    public void onMiningButtonClicked()
    {
        if(mapGenerator != null && characterMovement != null)
        {
            //Debug.Log("aze");
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
            int targetY = Mathf.FloorToInt(posY);

            switch (joystickFacingDirection)
            {
                case CharacterMovement.JoystickFacingDirection.Up:
                    //targetX = Mathf.RoundToInt(posX);
                    targetY++;
                    break;
                case CharacterMovement.JoystickFacingDirection.Down:
                    //targetX = Mathf.RoundToInt(posX);
                    targetY--;
                    break;
                case CharacterMovement.JoystickFacingDirection.Left:
                case CharacterMovement.JoystickFacingDirection.Right:
                case CharacterMovement.JoystickFacingDirection.None:
                    int targetDir = isPlayerFacingLeft ? -1 : 1;
                    targetX += targetDir;
                    break;
            }

            GameObject block = mapGenerator.GetBlock(targetX, targetY);
            if (block == null)
            {
                miningButton.timePressed = 0.0f;
                return;
            }

            // TODO: si le block est un piège casser instanement

            float health = block.GetComponent<Block>().Health;
            if(miningButton.timePressed > health)
            {
                //Debug.Log("x: " + targetX + "  y: " + targetY);
                mapGenerator.MineBlock(targetX, targetY);
                miningButton.timePressed = 0.0f;
            }
        }
    }
}
