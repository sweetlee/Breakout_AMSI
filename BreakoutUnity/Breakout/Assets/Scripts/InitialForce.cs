using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InitialForce : MonoBehaviour {
    private Rigidbody2D rigidbodyComponent;
    public bool randomStart = true;

    public Vector2 direction = new Vector2(1f, 1f);
    public float forceValue = 10f;

    void Start () {

        rigidbodyComponent = this.GetComponent<Rigidbody2D>();
        rigidbodyComponent.AddTorque(Random.Range(-3f, 3f));
        Vector2 force = Vector2.zero;

        if (this.randomStart)
        {
            force = new Vector2(Random.Range(-10f, 10f), Random.Range(-1f, 1f)).normalized * this.forceValue;
        } else
        {
            force = this.direction.normalized * this.forceValue;
        }
        rigidbodyComponent.AddForce(force);
    }
}