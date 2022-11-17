using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattlerHandler : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    //public Animator PlayerAnimator;
    //public Animator EnemyAnimator;

    Unit _playerUnit;
    Unit _enemyUnit;
    public gameOverScreen gameOverScreen;
    public BattleState gameState;
    public Text dialogText;
    public BattlerHud playerHUD;
    public BattlerHud enemyHUD;
    // Start is called before the first frame update
    void Start()
    {
        gameState = BattleState.START;
        StartCoroutine(BattleSetup());
        //PlayerAnimator = playerPrefab.GetComponent<Animator>();
    }

    //Setting up the scene of the game
    IEnumerator BattleSetup()
    {
        GameObject playerGameObject = Instantiate(playerPrefab, playerBattleStation); //Instantiate the player on their battle station
        _playerUnit = playerGameObject.GetComponent<Unit>(); //Get the unit information

        GameObject enemyGameObject = Instantiate(enemyPrefab, enemyBattleStation); //Instantiate the enemy on their battle station
        _enemyUnit = enemyGameObject.GetComponent<Unit>();

        dialogText.text = "The enemy " + _enemyUnit.characterName + " has appear!";

        playerHUD.SetBattleHud(_playerUnit);
        enemyHUD.SetBattleHud(_enemyUnit);

        yield return new WaitForSeconds(4f); //wait before letting the player pick an action button;

        gameState = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool characterisDead = _enemyUnit.TakeDamage(_playerUnit.damage);

        enemyHUD.SetHPValue(_enemyUnit.currentHP);

        dialogText.text = "You caused damage to the enemy!!";

        yield return new WaitForSeconds(2f);

        if (characterisDead)
        {
            gameState = BattleState.WON;
            BattleComplete();
        } else
        {
            gameState = BattleState.ENEMYTURN;
            StartCoroutine(EnemyAttackTurn());
        }
        

    }

    

    IEnumerator EnemyAttackTurn()
    {
        dialogText.text = _enemyUnit.characterName + " enemy attacks!";

        yield return new WaitForSeconds(1f);

        bool characterisDead = _playerUnit.TakeDamage(_enemyUnit.damage);

        playerHUD.SetHPValue(_playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (characterisDead)
        {
            gameState = BattleState.LOST;
            BattleComplete();
        } else
        {
            gameState = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void BattleComplete() //Show text when either the player or the enemy win
    {
        
        if (gameState == BattleState.WON)
        {
            dialogText.text = "Victory to you!!";
            gameOverScreen.SetupgameOver();
        } else if (gameState == BattleState.LOST)
        {
            dialogText.text = "You have been killed";
            gameOverScreen.SetupgameOver();
        }
    }

    void PlayerTurn() //Ask player to choose attack or heal
    {
       
        dialogText.text = "Choose an action:";
        
    }

    IEnumerator PlayerHeal()
    {
        _playerUnit.HealPlayer(5);

        gameState = BattleState.ENEMYTURN;

        playerHUD.SetHPValue(_playerUnit.currentHP);
        dialogText.text = "Renewed your strength!";

        yield return new WaitForSeconds(2f);

        StartCoroutine(EnemyAttackTurn());
    }

    public void AttackButton()
    {
        //When the player turn start, aka. when the attack button is pressed or not
        if (gameState != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
        
    }

    public void HealButton()
    {
        //When the player turn start, aka. when the heal button is pressed or not
        if (gameState != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());


    }
}
