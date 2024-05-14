// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "Sections.generated.h"

/**
 * 
 */
UCLASS()
class WEBSITEUEMOCKUP_API USections : public UUserWidget
{
	GENERATED_BODY()
	
private:
	UPROPERTY()
	TArray<FString> _Sections;

	UPROPERTY()
	FString _ActiveSection;

	UPROPERTY()
	float _VerticalPadding;

	UPROPERTY()
	class UVerticalBox* _VerticalBoxRef;

	UPROPERTY()
	TSubclassOf<UUserWidget> _SectionTextClass;

	UFUNCTION()
	void ConstructSections(const TArray<FString>& inSections);

protected:

	UPROPERTY(BlueprintReadWrite)
	float TextSize = 32;

	UFUNCTION(BlueprintCallable)
	void Init(class UVerticalBox* inVerticalBoxRef, TSubclassOf<class USectionText> inSectionTextClass);

public:
	UFUNCTION(BlueprintCallable)
	void Constructor(const TArray<FString>& inSections, const FString& inActiveSection, const float& inVerticalPadding);

	UFUNCTION(BlueprintCallable)
	TArray<FString> GetSectionsToDisplay(const TArray<FString>& inSections, const FString& inActiveSection);

	UFUNCTION(BlueprintCallable)
	void SetMargin(const float& inVerticalPadding);
};
