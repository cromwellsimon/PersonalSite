// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "WebsiteUEMockupUtils.generated.h"

/**
 * 
 */
UCLASS()
class WEBSITEUEMOCKUP_API UWebsiteUEMockupUtils : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()

	UFUNCTION(BlueprintCallable)
	static TArray<class USectionCardDataAsset*> InstantiateSampleData();
};
