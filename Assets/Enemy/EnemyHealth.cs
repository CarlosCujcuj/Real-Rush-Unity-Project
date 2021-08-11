using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]  //asegura que el script Enemy siempre se adjunte al GameObject
                                    // a la hora de adjuntar el script EnemyHealth (este script)

public class EnemyHealth : MonoBehaviour{

    [SerializeField] int maxHitPoints = 7;

    [Tooltip("Adds amount to maxHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;

    Enemy enemy;

    // Start is called before the first frame update
    void Start(){
        enemy = GetComponent<Enemy>();
    }

    void OnEnable(){
        
        currentHitPoints = maxHitPoints;

    }

    private void OnParticleCollision(GameObject other) {

        ProcessHit();
        
    }

    void ProcessHit(){

        currentHitPoints--;

        if(currentHitPoints <= 0){
            //Destroy(gameObject);
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
