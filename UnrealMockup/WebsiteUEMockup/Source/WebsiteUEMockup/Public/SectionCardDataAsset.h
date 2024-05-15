// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "SectionCardData.h"
#include "SectionCardDataAsset.generated.h"

/**
 * 
 */
UCLASS(BlueprintType)
class WEBSITEUEMOCKUP_API USectionCardDataAsset : public UDataAsset
{
	GENERATED_BODY()
	
public:
	UPROPERTY(BlueprintReadWrite)
	FString SectionTitle;

	UPROPERTY(BlueprintReadWrite)
	TArray<class UCardDataAsset*> CardData;

	UPROPERTY(BlueprintReadWrite)
	int32 SelectedCardIndex = 1;

	UFUNCTION(BlueprintCallable)
	// An int32& on 64-bit machines is larger than an int32 since a memory address is 64 bits while an int32 is obviously 32 bits.
	// Also, https://forums.unrealengine.com/t/varargs-or-optional-variable-parameters-in-ufunction/509422 claims that it's impossible to do varargs for BlueprintCallable functions,
	// but then how does the Make Array Node work in Blueprint? Is that not an example of varargs? Oh well
	static USectionCardDataAsset* Instantiate(const FString& inSectionTitle, const TArray<class UCardDataAsset*>& inCardData, const int32 inSelectedCardIndex = 1);
};
