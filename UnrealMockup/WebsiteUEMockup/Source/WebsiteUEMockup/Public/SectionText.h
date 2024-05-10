// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "SectionText.generated.h"

/**
 * 
 */
UCLASS()
class WEBSITEUEMOCKUP_API USectionText : public UUserWidget
{
	GENERATED_BODY()
	
private:
	UPROPERTY()
	FText _Text;

protected:
	UPROPERTY(BlueprintReadWrite)
	class UTextBlock* TextBlockRef;

	UFUNCTION(BlueprintCallable)
	void Init(class UTextBlock* inTextBlockRef);

public:
	UFUNCTION(BlueprintCallable)
	void Constructor(const FText& inText);

	UFUNCTION(BlueprintCallable)
	void SetText(const FText& inText);

	UFUNCTION(BlueprintCallable)
	FText GetText();

	UFUNCTION(BlueprintCallable)
	void SetSize(const float& inSize);

	UFUNCTION(BlueprintCallable)
	float GetSize();
};
