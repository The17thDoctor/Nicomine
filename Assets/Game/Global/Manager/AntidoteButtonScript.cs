using UnityEngine;
using UnityEngine.UI;

public class AntidoteButtonScript : MonoBehaviour
{
    public CharacterSpriteManager characterSprite;
    public GameManager gameManager;
    void Start()
    {
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(HealChoice);
    }
    private void HealChoice()
    {
        if (characterSprite.getIsPlayerInVillage() && gameManager.getSickPeople()>0)
        {
            gameManager.setStatePeople(gameManager.getSainPeople() + 1, gameManager.getSickPeople() - 1, gameManager.getDeadPeople());
        }
    }
}
