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

	UPROPERTY(BlueprintReadWrite)
	int32 SelectedCardIndex = 1;

	FSectionCardData(){}

	static FSectionCardData Instantiate(const FString& inSectionTitle, const TArray<FCardData>& inCardData, int32 inSelectedCardIndex = 1);
};

UCLASS()
class WEBSITEUEMOCKUP_API USectionCardDataStatics : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()

public:
	UFUNCTION(BlueprintCallable)
	static FSectionCardData Instantiate(const FString& inSectionTitle, const TArray<FCardData>& inCardData, int32 inSelectedCardIndex = 1);
};
