// Fill out your copyright notice in the Description page of Project Settings.


#include "Card.h"
#include "Components/TextBlock.h"
#include "Components/Image.h"

void UCard::Init(UTextBlock* inTitleTextBlockRef, UTextBlock* inSubtitleTextBlockRef, UImage* inImageRef)
{
	_TitleTextBlockRef = inTitleTextBlockRef;
	_SubtitleTextBlockRef = inSubtitleTextBlockRef;
	_ImageRef = inImageRef;
}

void UCard::Constructor(const FCardData& inCardData)
{
	_CardData = inCardData;
	SetTitle(_CardData.Title);
	SetSubtitle(_CardData.Subtitle);
	SetTexture(_CardData.Texture);
}

void UCard::SetTitle(const FString& inTitle)
{
	_CardData.Title = inTitle;
	_TitleTextBlockRef->SetText(FText::FromString(_CardData.Title));
}

const FString& UCard::GetTitle()
{
	return _CardData.Title;
}

void UCard::SetSubtitle(const FString& inSubtitle)
{
	_CardData.Subtitle = inSubtitle;
	_SubtitleTextBlockRef->SetText(FText::FromString(_CardData.Subtitle));
}

void UCard::SetTexture(UTexture2D* inTexture)
{
	_CardData.Texture = inTexture;
	_ImageRef->SetBrushFromTexture(_CardData.Texture);
}
