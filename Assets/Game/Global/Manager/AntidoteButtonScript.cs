using UnityEngine;
using UnityEngine.UI;

public class AntidoteButtonScript : MonoBehaviour
{
    private CharacterSpriteManager characterSprite;
    private GameManager gameManager;
    private Inventory stockage;
    void Start()
    {
        stockage = GameObject.FindObjectsOfType<Inventory>()[0];
        gameManager = GameObject.FindObjectsOfType<GameManager>()[0];
        characterSprite = GameObject.FindObjectsOfType<CharacterSpriteManager>()[0];
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(HealChoice);
    }
    private void HealChoice()
    {
        if (characterSprite.getIsPlayerInVillage() && gameManager.getSickPeople()>0 && stockage.Antidotes != 0)
        {
            stockage.Antidotes--;
            gameManager.AddToScore(ScoreValue.VILLAGER_HEALED);
            gameManager.setStatePeople(gameManager.getSainPeople() + 1, gameManager.getSickPeople() - 1, gameManager.getDeadPeople());
        }
    }
}
