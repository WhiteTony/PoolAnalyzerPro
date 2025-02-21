#ifndef EVENT_H
#define EVENT_H

#include <Arduino.h>
#include <RTClib.h>
#include <BluetoothSerial.h>
#include <DallasTemperature.h>
#include <TFT_eSPI.h>

struct UnwantedEvent
{
    String type;
    String highLow;
    double value;
    DateTime time;
};



float getTemperature(DallasTemperature* sensor);
float getPh(int poPin);
float ec2Tds(float ec25);
String sendTempString(double temperature);
String sendTdsString(double tds);
void sendTemperatureTooLow(float temperature);
void sendTemperatureTooHigh(float temperature);
void sendTemperature(double temperature, BluetoothSerial* SerialBT);
void sendTds(double tds, BluetoothSerial* SerialBT);
void printTime(DateTime now, TFT_eSPI* tft, int x, int y);
void drawMinMax(double tempMax, double tempMin, int tdsMax, int tdsMin, double phMax, double phMin, TFT_eSPI* tft);












#endif


