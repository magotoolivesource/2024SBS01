using UnityEngine;

public class TargetNavigation : MonoBehaviour
{
    public E_NaigationType LineID = 0;
    public TargetNavigation NextTarget;

    public Color GizmoLineColor = Color.red;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        BaseActor actor = collision.GetComponent<BaseActor>();
        if (actor == null)
        {
            return;
        }

        if(actor.MoveID == LineID)
        {
            actor.SetTarget(NextTarget.transform);
        }
        
        

    }


    public float ArrowHeadSize = 0.2f;
    //public Mesh linkMesh = null;
    private void OnDrawGizmos()
    {
        if (NextTarget == null)
            return;

        //Gizmos
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, NextTarget.transform.position);
        //Gizmos.DrawLineStrip()


        // 화살표 그리기용
        // https://www.reddit.com/r/Unity3D/comments/16p3xqy/simple_arrow_gizmo/?rdt=49651
        Vector3 direction = NextTarget.transform.position - transform.position;
        //direction.Normalize();
        DrawArrowGizmo(transform.position
            , direction.normalized
            , direction.magnitude
            , ArrowHeadSize
            , GizmoLineColor);



        //DrawArrowGizmo();

    }

    public float Length;
    public float HeadSize;
    public static void DrawArrowGizmo( Vector3 p_stpos
        , Vector3 p_direction
        , float p_length, float p_headsize, Color p_color)
    {
        // 내적 = 회전값
        // 외적 = , 내적
        Gizmos.color = p_color;

        Vector3 arrowHead;
        Vector3 arrowRim;

        arrowHead = p_stpos + p_length * p_direction;
        arrowRim = p_stpos + p_length * 0.66f * p_direction;


        Vector3 up = Vector3.up;
        Vector3 forward = Vector3.Cross(p_direction, up);
        up = Vector3.Cross(p_direction, forward);
        up.Normalize();


        Gizmos.DrawLine(p_stpos, arrowHead);
        Gizmos.DrawLineStrip(new Vector3[3] { arrowRim + up * p_length * p_headsize
                , arrowHead
                , arrowRim - up * p_length * p_headsize }, true);
        Gizmos.DrawLineStrip(new Vector3[3] { arrowRim + forward * p_length * p_headsize
                , arrowHead
                , arrowRim - forward * p_length * p_headsize }, true);
    }

    public void DrawArrowGizmo()
    {
        Gizmos.color = Color.red;

        Vector3 arrowHead;
        Vector3 arrowRim;

        arrowHead = transform.position + Length * transform.right;
        arrowRim = transform.position + Length * 0.66f * transform.right;

        Gizmos.DrawLine(transform.position, arrowHead);
        Gizmos.DrawLineStrip(new Vector3[3] { arrowRim + transform.up * Length * HeadSize, arrowHead, arrowRim - transform.up * Length * HeadSize }, true);
        Gizmos.DrawLineStrip(new Vector3[3] { arrowRim + transform.forward * Length * HeadSize, arrowHead, arrowRim - transform.forward * Length * HeadSize }, true);
    }







    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
