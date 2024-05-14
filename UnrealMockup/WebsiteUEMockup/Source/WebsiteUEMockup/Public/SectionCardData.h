// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine.h"
#include "Engine/DataTable.h"
#include "CardData.h"
#include "SectionCardData.generated.h"

USTRUCT(BlueprintType)
struct WEBSITEUEMOCKUP_API FSectionCardData : public FTableRowBase
{
	GENERATED_USTRUCT_BODY()

public:
	UPROPERTY(BlueprintReadWrite)
	FString SectionTitle;

	UPROPERTY(BlueprintReadWrite)
	TArray<FCardData> CardData;

	FSectionCardData(){}
};