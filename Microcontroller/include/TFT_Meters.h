#ifndef TFT_METERS_H
#define TFT_METERS_H


#include <Arduino.h>
#include <TFT_eSPI.h> // Hardware-specific library
#include <SPI.h>
#include <Time.h>


//TFT_eSPI tft =  TFT_eSPI();



#define TFT_GREY 0x5AEB
#define LOOP_PERIOD 35 // Display updates every 35 ms

//LCD screen dimensions
#define WIDTH 240
#define HEIGHT 320

//Function declarations
void topDisplay(TFT_eSPI* tft);
void plotNeedle(TFT_eSPI* tft, int value, byte ms_delay);
void analogMeter(TFT_eSPI* tft);
void plotLinear(TFT_eSPI* tft, char *label, int x, int y, int meterWidth);
void plotPointer(TFT_eSPI* tft, int* value, double* valueDouble, int* oldValue, int meterDistance, int meterWidth);


#endif
//TFT_METERS_H