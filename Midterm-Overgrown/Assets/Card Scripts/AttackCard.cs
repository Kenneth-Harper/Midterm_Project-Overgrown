using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    [SerializeField] protected int _attackDamage = 6;
    protected Enemy Target;

    private void OnMouseDrag() 
    {
        gameObject.transform.position = new Vector3(-10.9f, -2.35f, gameObject.transform.position.z);
        Player.instance._IsTargeting = true;    
    }

    private void OnMouseUp() 
    {
        if (Player.instance._IsTargeting)
        {
            Player.instance._IsTargeting = false;
            gameObject.transform.position = this._PlaceWhenInHand;
            if (Player.instance._CurrentTarget != null && Player.instance.CanPlayCard(this._energyCost))
            {
                Target = Player.instance._CurrentTarget.GetComponent<Enemy>();
                AffectEnemy();
                CardPlayed();
            }
        }
    }

    private void CardPlayed()
    {
        Player.instance.PlayCard(this._PlaceInHand);
        Player.instance.SpendEnergy(_energyCost);
        Destroy(gameObject);
    }

    public virtual void AffectEnemy()
    {
        this.Target.EnemyTakeDamage(this._attackDamage);
    }

    void Update()
    {
        
    }
}
