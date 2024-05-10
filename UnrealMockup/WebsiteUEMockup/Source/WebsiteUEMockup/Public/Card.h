// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "Card.generated.h"

/**
 * 
 */
UCLASS()
class WEBSITEUEMOCKUP_API UCard : public UUserWidget
{
	GENERATED_BODY()
	
private:
	UPROPERTY()
	FText _Text;

	UPROPERTY()
	class UTexture2D* _Texture;

protected:
	UPROPERTY(BlueprintReadWrite)
	class UTextBlock* TextBlockRef;

	UPROPERTY(BlueprintReadWrite)
	class UImage* ImageRef;

	UFUNCTION(BlueprintCallable)
	void Init(class UTextBlock* inTextBlockRef, class UImage* inImageRef);

public:
	UFUNCTION(BlueprintCallable)
	void Constructor(const FText& inText, UTexture2D* inTexture);

	UFUNCTION(BlueprintCallable)
	void SetText(const FText& inText);

	UFUNCTION(BlueprintCallable)
	const FText& GetText();

	UFUNCTION(BlueprintCallable)
	void SetTexture(UTexture2D* inTexture);
};
