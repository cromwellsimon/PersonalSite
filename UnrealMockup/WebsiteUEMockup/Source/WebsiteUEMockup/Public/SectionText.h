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
	FString _Text;

protected:
	UPROPERTY(BlueprintReadWrite)
	class UTextBlock* _TextBlockRef;

	UFUNCTION(BlueprintCallable)
	void Init(class UTextBlock* inTextBlockRef);

public:
	UFUNCTION(BlueprintCallable)
	void Constructor(const FString& inText);

	UFUNCTION(BlueprintCallable)
	void SetText(const FString& inText);

	UFUNCTION(BlueprintCallable)
	FString GetText();

	UFUNCTION(BlueprintCallable)
	void SetSize(const float& inSize);

	UFUNCTION(BlueprintCallable)
	float GetSize();
};
