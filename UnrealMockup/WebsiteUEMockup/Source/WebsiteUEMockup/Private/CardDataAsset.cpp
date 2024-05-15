// Fill out your copyright notice in the Description page of Project Settings.


#include "CardDataAsset.h"

UCardDataAsset* UCardDataAsset::Instantiate(UTexture2D* inTexture, const FString& inTitle, const FString& inSubtitle)
{
	auto instance = NewObject<UCardDataAsset>();
	instance->Texture = inTexture;
	instance->Title = inTitle;
	instance->Subtitle = inSubtitle;
	return instance;
}

UCardDataAsset* UCardDataAsset::Default()
{
	return Instantiate(nullptr, TEXT(""), TEXT(""));
}
