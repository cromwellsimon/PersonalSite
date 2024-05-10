// Fill out your copyright notice in the Description page of Project Settings.


#include "Card.h"
#include "Components/TextBlock.h"
#include "Components/Image.h"

void UCard::Init(UTextBlock* inTextBlockRef, UImage* inImageRef)
{
	TextBlockRef = inTextBlockRef;
	ImageRef = inImageRef;
}

void UCard::Constructor(const FText& inText, UTexture2D* inTexture)
{
	SetText(inText);
	SetTexture(inTexture);
}

void UCard::SetText(const FText& inText)
{
	_Text = inText;
	TextBlockRef->SetText(inText);
}

const FText& UCard::GetText()
{
	return _Text;
}

void UCard::SetTexture(UTexture2D* inTexture)
{
	_Texture = inTexture;
	ImageRef->SetBrushFromTexture(_Texture);
}
