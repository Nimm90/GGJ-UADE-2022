// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess( typeof( InvertedPPSRenderer ), PostProcessEvent.AfterStack, "Inverted", true )]
public sealed class InvertedPPSSettings : PostProcessEffectSettings
{
	[Tooltip( "UDisplacement" )]
	public FloatParameter _UDisplacement = new FloatParameter { value = 0f };
}

public sealed class InvertedPPSRenderer : PostProcessEffectRenderer<InvertedPPSSettings>
{
	public override void Render( PostProcessRenderContext context )
	{
		var sheet = context.propertySheets.Get( Shader.Find( "Inverted" ) );
		sheet.properties.SetFloat( "_UDisplacement", settings._UDisplacement );
		context.command.BlitFullscreenTriangle( context.source, context.destination, sheet, 0 );
	}
}
#endif
