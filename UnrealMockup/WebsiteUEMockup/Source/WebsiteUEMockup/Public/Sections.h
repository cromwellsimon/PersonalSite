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
	TArray<FText> _Sections;

	UPROPERTY()
	FText _ActiveSection;

	UPROPERTY()
	float _VerticalPadding;

protected:
	UPROPERTY(BlueprintReadWrite)
	class UVerticalBox* VerticalBoxRef;

	UPROPERTY(BlueprintReadWrite)
	TSubclassOf<UUserWidget> SectionTextClass;

	UPROPERTY(BlueprintReadWrite)
	float TextSize = 32;

	UFUNCTION(BlueprintCallable)
	void Init(class UVerticalBox* inVerticalBoxRef, TSubclassOf<UUserWidget> inSectionTextClass);

public:
	UFUNCTION(BlueprintCallable)
	void Constructor(const TArray<FText>& inSections, const FText& inActiveSection, const float& inVerticalPadding);

	UFUNCTION(BlueprintCallable)
	void SetSections(const TArray<FText>& inSections);

	UFUNCTION(BlueprintCallable)
	void SetActiveSection(const FText& inActiveSection);

	UFUNCTION(BlueprintCallable)
	void SetMargin(const float& inVerticalPadding);
};
