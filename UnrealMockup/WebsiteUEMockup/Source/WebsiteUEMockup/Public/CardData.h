// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine.h"
#include "Engine/DataTable.h"
#include "CardData.generated.h"

USTRUCT(BlueprintType)
struct WEBSITEUEMOCKUP_API FCardData : public FTableRowBase
{
	GENERATED_USTRUCT_BODY()

public:
	UPROPERTY(BlueprintReadWrite)
	UTexture2D* Texture;

	UPROPERTY(BlueprintReadWrite)
	FString Title;

	UPROPERTY(BlueprintReadWrite)
	FString Subtitle;

	FCardData(){}
};