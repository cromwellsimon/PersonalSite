// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "SectionCardData.h"
#include "Dashboard.generated.h"

/**
 * 
 */
UCLASS()
class WEBSITEUEMOCKUP_API UDashboard : public UUserWidget
{
	GENERATED_BODY()
	
private:
	UPROPERTY()
	class UCardRoulette* _CardRoulette;

	UPROPERTY()
	class USections* _Sections;

	UPROPERTY()
	TArray<FSectionCardData> _SectionCardData;

	UPROPERTY()
	FString _ActiveSection;

protected:
	UFUNCTION(BlueprintCallable)
	void Init(class UCardRoulette* inCardRoulette, class USections* inSections);

public:
	UFUNCTION(BlueprintCallable)
	void Constructor(const TArray<FSectionCardData>& inSectionCardData, const FString& inActiveSection);

	UFUNCTION(BlueprintCallable, BlueprintPure)
	const int32 GetActiveSectionIndex();

	UFUNCTION(BlueprintCallable)
	void MoveSection(bool upwards = true);

	UFUNCTION(BlueprintCallable)
	void MoveCard(bool rightwards = true);
};
