// Fill out your copyright notice in the Description page of Project Settings.


#include "SectionText.h"
#include "Components/TextBlock.h"
#include "Fonts/SlateFontInfo.h"

void USectionText::Init(UTextBlock* inTextBlockRef)
{
	_TextBlockRef = inTextBlockRef;
}

void USectionText::Constructor(const FString& inText)
{
	SetText(inText);
}

void USectionText::SetText(const FString& inText)
{
	_Text = inText;
	// In most circumstances, you'd want to put a nullptr check here.
	// However, in this instance, TextBlock should have been set to something.
	// If it hasn't been set to anything, I want it to fail to make it immediately obvious.
	_TextBlockRef->SetText(FText::FromString(_Text));
}

FString USectionText::GetText()
{
	return _TextBlockRef->GetText().ToString();
}

void USectionText::SetSize(const float& inSize)
{
	FSlateFontInfo oldFont = _TextBlockRef->GetFont();
	oldFont.Size = inSize;
	_TextBlockRef->SetFont(oldFont);
}

float USectionText::GetSize()
{
	return _TextBlockRef->GetFont().Size;
}