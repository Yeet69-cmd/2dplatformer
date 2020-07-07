using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{

    public Slider healthSlider;
    const float MAXHEALTH = 10f;
    float health;

// Start is called before the first frame update
    void Start()
    {

        health = MAXHEALTH;
    }


    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
        // UPDATE THE SLIDER
        healthSlider.value = health / MAXHEALTH;
    }


    void Die()
    {
        GetComponent<CharacerController2D>().enabled = false;
        GetComponent<Animator>().SetBool("Dead", true);
    }
    public void GetHealth(float amount)
    {
        health += amount;

        if (health > MAXHEALTH)
        {
            health = MAXHEALTH;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            GetHealth(5);
            Destroy(other.gameObject);
        }
        // UPDATE THE SLIDER
        healthSlider.value = health / MAXHEALTH;
    }

}
