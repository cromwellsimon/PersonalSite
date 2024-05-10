// Fill out your copyright notice in the Description page of Project Settings.


#include "SectionText.h"
#include "Components/TextBlock.h"
#include "Fonts/SlateFontInfo.h"

void USectionText::Init(UTextBlock* inTextBlockRef)
{
	TextBlockRef = inTextBlockRef;
}

void USectionText::Constructor(const FText& inText)
{
	SetText(inText);
}

void USectionText::SetText(const FText& inText)
{
	_Text = inText;
	// In most circumstances, you'd want to put a nullptr check here.
	// However, in this instance, TextBlock should have been set to something.
	// If it hasn't been set to anything, I want it to fail to make it immediately obvious.
	TextBlockRef->SetText(_Text);
}

FText USectionText::GetText()
{
	return TextBlockRef->GetText();
}

void USectionText::SetSize(const float& inSize)
{
	FSlateFontInfo oldFont = TextBlockRef->GetFont();
	oldFont.Size = inSize;
	TextBlockRef->SetFont(oldFont);
}

float USectionText::GetSize()
{
	return TextBlockRef->GetFont().Size;
}