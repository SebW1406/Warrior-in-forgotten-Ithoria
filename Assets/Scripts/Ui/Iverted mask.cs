// Source - https://stackoverflow.com/a/75125021
// Posted by Nk Pstl, modified by community. See post 'Timeline' for change history
// Retrieved 2026-07-07, License - CC BY-SA 4.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class UIMaskFilter : Image
{
    public override Material materialForRendering
    {
        get // comparison exchange - maske normal modell kopiert und mit name
            // auf invertierte maske umgeschrieben
        {
            Material material = new Material(base.materialForRendering);
            material.SetFloat("_StencilComp", (float)CompareFunction.NotEqual);
            return material;
        }
    }
}
