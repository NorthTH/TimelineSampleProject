using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TextSpaceController : BaseMeshEffect {

    public float moveWeight;
    Vector3 moveDir = Vector3.right;
    float time = 0;

    public override void ModifyMesh ( UnityEngine.UI.VertexHelper vh)
    {
        if (!IsActive())
            return;

        List<UIVertex> vertices = new List<UIVertex>();
        vh.GetUIVertexStream(vertices);

        TextMove(ref vertices);

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertices);
    }

    void TextMove( ref List<UIVertex> vertices )
    {
        var textCount = vertices.Count / 6;

        for (int firstChar = 0; firstChar < textCount; firstChar ++)
        {
            int firstVertice = firstChar * 6;

            float weight =  (firstChar - (textCount / 2.0f)) / (textCount / 2.0f);

            Vector3 dir = moveDir * moveWeight;

            for(int i = 0; i < 6; i++)
            {
                var vert       = vertices[firstVertice + i];
                vert.position  = vert.position + (dir * weight);
                vertices[firstVertice + i] = vert;
            }
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.01f)
        {
            time = 0;
            base.graphic.SetVerticesDirty ();
        }
    }
}
