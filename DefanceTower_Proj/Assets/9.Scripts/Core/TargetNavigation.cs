using UnityEngine;

public class TargetNavigation : MonoBehaviour
{

    public TargetNavigation NextTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        BaseActor actor = collision.GetComponent<BaseActor>();
        if (actor == null)
        {
            return;
        }

        actor.SetTarget( NextTarget.transform );

    }


    //public Mesh linkMesh = null;
    private void OnDrawGizmos()
    {
        if (NextTarget == null)
            return;

        //Gizmos
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, NextTarget.transform.position);
        //Gizmos.DrawLineStrip()

    }







    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
