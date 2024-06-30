using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UIElements;



public static class EXTransform
{
    public static T GetComponentInChildrenNName<T>( this Component p_compoment
        , string p_name) where T : Component
    {
        var allcomarr = p_compoment.GetComponentsInChildren<T>(true);
        foreach ( var c in allcomarr )
        {
            if (c.name == p_name)
                return c;
        }

        return null;

    }
}


public class ExtendCore
{



    public static List<T> GetRangeObjectAll<T>(Vector2 p_centerpos
        , float p_farradius
        , LayerMask p_mask
        , float p_nearraius = 0f
        ) where T : Component
    {
        List<T> result = new List<T>();

        Collider2D[] collider2darr = Physics2D.OverlapCircleAll(p_centerpos
           , p_farradius
           , p_mask);

        foreach (var item in collider2darr)
        {
            T tempobj = item.GetComponent<T>();
            if(tempobj)
            {
                result.Add(tempobj);
            }
        }

        return result;
    }


    public static T GetRangeObject<T>(Vector2 p_centerpos
        , float p_farradius
        , LayerMask p_mask
        , float p_nearraius = 0f
        ) where T : Component
    {
        Collider2D[] collider2darr = Physics2D.OverlapCircleAll(p_centerpos
           , p_farradius
           , p_mask);

        if (collider2darr.Length <= 0)
            return null;

        T result = null;
        T tempobj = null;
        float length = float.MaxValue;

        float nearsqrmanitude = p_nearraius * p_nearraius;
        foreach (var item in collider2darr)
        {
            tempobj = item.GetComponent<T>();
            if (tempobj == null) continue;


            Vector2 direction = p_centerpos - (Vector2)item.transform.position;
            if (direction.sqrMagnitude <= nearsqrmanitude)
                continue;

            if (direction.sqrMagnitude < length)
            {
                result = tempobj;
                length = direction.sqrMagnitude;
            }
        }

        return result;
    }


    public static T GetRangeFarObject<T>(Vector2 p_centerpos
        , float p_radius
        , LayerMask p_mask) where T : Component
    {
        Collider2D[] collider2darr = Physics2D.OverlapCircleAll(p_centerpos
            , p_radius
            , p_mask);

        if (collider2darr.Length <= 0)
            return null;

        T result = null;
        T tempobj = null;
        float length = 0f;
        
        foreach (var item in collider2darr)
        {
            tempobj = item.GetComponent<T>();
            if (tempobj == null) continue;

            Vector2 direction = p_centerpos - (Vector2)item.transform.position;
            if( direction.sqrMagnitude > length )
            {
                result = tempobj;
                length = direction.sqrMagnitude;
            }
        }

        return result;
    }

    public static T GetRangeObject<T>(Vector2 p_centerpos
        , float p_radius
        , LayerMask p_mask ) where T : Component
    {
        Collider2D collider2d = Physics2D.OverlapCircle(p_centerpos
            , p_radius
            , p_mask);

        if (collider2d == null)
        {
            return null;
        }

        return collider2d.GetComponent<T>();
    }


    public static void DrawArrowGizmo(Vector3 p_stpos
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

}
