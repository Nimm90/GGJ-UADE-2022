// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>

#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PixelatedPPSRenderer), PostProcessEvent.AfterStack, "Pixelated", true)]
public sealed class PixelatedPPSSettings : PostProcessEffectSettings
{
    [Tooltip("XPixels")] [Range(4, 1920)] public FloatParameter _XPixels = new FloatParameter {value = 144f};
    [Range(4, 1080)] [Tooltip("YPixels")] public FloatParameter _YPixels = new FloatParameter {value = 144f};
}

public sealed class PixelatedPPSRenderer : PostProcessEffectRenderer<PixelatedPPSSettings>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Pixelated"));
        sheet.properties.SetFloat("_XPixels", settings._XPixels);
        sheet.properties.SetFloat("_YPixels", settings._YPixels);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
#endif