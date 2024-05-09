// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine.h"
#include "Engine/DataTable.h"
#include "Course.generated.h"

USTRUCT(BlueprintType)
struct WEBSITEUEMOCKUP_API FCourse : public FTableRowBase
{
	GENERATED_USTRUCT_BODY()

public:
	UPROPERTY(VisibleAnywhere, BlueprintReadWrite)
	FText Name;

	UPROPERTY(VisibleAnywhere, BlueprintReadWrite)
	FString Url;

	UPROPERTY(VisibleAnywhere, BlueprintReadWrite)
	FText Review;

	UPROPERTY(VisibleAnywhere, BlueprintReadWrite)
	FDateTime GeneralCompletionDate;

	UPROPERTY(VisibleAnywhere, BlueprintReadWrite)
	FString Notes;

	FCourse(){}
};