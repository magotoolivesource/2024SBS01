using UnityEngine;

public class UGUIExtendFNs
{


    public static (Bounds, bool) WorldBound2UGUIScreenSize(Bounds p_3dbound
        , Camera p_ingamecam
        , Canvas p_canvas
        , RectTransform p_parenttrasn )
    {
        Bounds outbound = new Bounds();

        Vector3 minpos = World2UGuiScreenWorldPos(p_3dbound.min, p_ingamecam, p_canvas);
        Vector3 maxpos = World2UGuiScreenWorldPos(p_3dbound.max, p_ingamecam, p_canvas);

        Camera uicam = p_canvas.worldCamera;
        if (p_canvas.renderMode != RenderMode.ScreenSpaceOverlay
            && uicam != null)
        {
            //outwpos = uicam.ScreenToWorldPoint(screenpos);
            //RectTransformUtility.CalculateRelativeRectTransformBounds()

        }


        return (outbound, false);
    }

    public static Vector3 World2UGuiScreenWorldPos(Vector3 p_worldpos
        , Camera p_ingamecam
        , Canvas p_canvas)
    {
        Vector3 outwpos = p_ingamecam.WorldToScreenPoint(p_worldpos);

        Vector3 screenpos = p_ingamecam.WorldToScreenPoint(p_worldpos);
        Camera uicam = p_canvas.worldCamera;
        if (p_canvas.renderMode != RenderMode.ScreenSpaceOverlay
            && uicam != null)
        {
            outwpos = uicam.ScreenToWorldPoint(screenpos);
        }

        return outwpos;
    }

    /// <summary>
    /// 3D 월드에서 2d 좌표로 변환하고 월드좌표로 반환함 recttransform 형태의 위치값으로 지정하지 않음
    /// </summary>
    /// <param name="p_worldpos"></param>
    /// <param name="p_ingamecam"></param>
    /// <param name="p_canvas"></param>
    /// <param name="p_parenttrans"></param>
    public static (Vector3, bool) World2UGuiScreenWorldPos2( Vector3 p_worldpos
        , Camera p_ingamecam
        , Canvas p_canvas
        , RectTransform p_parenttrans )
    {
        Vector3 outwpos = p_ingamecam.WorldToScreenPoint(p_worldpos);

        Vector3 screenpos = p_ingamecam.WorldToScreenPoint( p_worldpos );
        Camera uicam = p_canvas.worldCamera;
        if (p_canvas.renderMode != RenderMode.ScreenSpaceOverlay
            && uicam != null )
        {
            outwpos = uicam.ScreenToWorldPoint(screenpos);
        }

        return (outwpos, false );
    }


    public static (Vector3, bool) World2UGuiRecttransformPos(Vector3 p_worldpos
        , Camera p_ingamecam
        , Canvas p_canvas
        , RectTransform p_parenttrans)
    {
        Vector3 outwpos = new Vector3();

        Vector3 screenpos = p_ingamecam.WorldToScreenPoint(p_worldpos);
        Camera uicam = p_canvas.worldCamera;
        if (p_canvas.renderMode != RenderMode.ScreenSpaceOverlay
            && uicam != null)
        {
            outwpos = uicam.ScreenToWorldPoint(screenpos);
        }

        return (outwpos, false);
    }


}
