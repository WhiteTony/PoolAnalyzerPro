#include <Arduino.h>
#include <TFT_Meters.h>
#include <Wire.h>
#include <RTClib.h>
#include <OneWire.h>
#include <BluetoothSerial.h>
#include <string>
#include <stdlib.h>
#include <DallasTemperature.h>
#include <PapLib.h>

#define UNWANTEDEVENTBREAK 5000
#define PH_PIN 35
#define EC_PIN 34
#define EC_GROUND 33
#define EC_POWER_PIN
#define EC_R1 220


using namespace std;

bool deleteEvents = false;
bool requestEvents = false;


double tempMin = 5;
double tempMax = 40;
int tdsMin = 0;
int tdsMax = 4000;
double phMin = 6;
double phMax = 10;

//TDS varialbes
int tdsTime2 = 5000;
int R1 = 220;
double Ra = 24.87; //Resistance of powering Pins
int ECPin = 34;
int ECGround= 33;
int ECPower = 32;
int nReadings = 0;
int ppmSum = 0;
//float PPMconversion = 0.76;
float TemperatureCoef = 0.019;
float K = 10.5;
float Temperature=10;
float EC = 0;
float EC25 = 0;
int ppm = 0;
float raw1 = 0;
volatile float raw = 0;
float Vin = 3.25;
float Vdrop = 0;
float Rc = 0;
bool minMaxChanged = false;

void btRxTaskCode( void * pvParameters );
BluetoothSerial SerialBT;
String btReceivedString;
char btReceivedChar;
TaskHandle_t btRxTask;
TaskHandle_t analyserTask;

float getTemp();
float GetEC(float temperature, vector<UnwantedEvent>* vector);
void PrintReadings();
float phSensor(int poPin);
void sendPh(double ph);
void printEvent(vector<UnwantedEvent> eventVector, int n);

//void drawMinMax();
void sendTemperatureTooLow(float temperature);
void sendTemperatureTooHigh(float temperature);
void sendTdsTooLow(float tds);
void sendTdsTooHigh(float tds);
void sendPhTooLow(float ph);
void sendPhTooHigh(float ph);
String sendTimeString(DateTime time);
String sendTempString(int temperature);
String sendTdsString(double tds);

float meanPpm = -1;
float tds;


TFT_eSPI tft =  TFT_eSPI();



char daysOfTheWeek[7][12] = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};

//LCD display variables
float ltx = 0;    // Saved x coord of bottom of needle
uint16_t osx = 120, osy = 120; // Saved x & y coords
uint32_t updateTime = 0;       // time for next update
uint32_t showTime = 0;
int old_analog =  -999; // Value last displayed
int old_digital = -999; // Value last displayed
int value[6] = {0, 0, 0, 0, 0, 0};
double valueDouble[6] = {0, 0, 0, 0, 0, 0};
int old_value[6] = { -1, -1, -1, -1, -1, -1};
int d = 0;
int meterWidth = WIDTH/3 - 4;
int meterHeight = HEIGHT/2;
int meterDistance = WIDTH/3;
int lcdDelPin = 19;
int tdsTime = 5000;
int temperatureTime = 5000;
int phTime = 5000;

//RTC variables
RTC_DS1307 rtc;

// Temperature probe variables
int DS18S20_Pin = 27;
OneWire ds(DS18S20_Pin);
DallasTemperature sensors(&ds);


// UnwantedEvent variables

vector<UnwantedEvent> unwantedEventVector;



void setup(void) 
{
  xTaskCreatePinnedToCore(btRxTaskCode, "btRxTask", 10000, NULL, 1, &btRxTask, 1);


  pinMode(14, INPUT); 
  pinMode(PH_PIN, INPUT);  
  tft.init();
  tft.setRotation(0);
  tft.fillScreen(TFT_BLACK);
  topDisplay(&tft);
    // Draw 3 linear meters
  plotLinear(&tft, "Temp(*C)", 0*meterDistance, meterHeight, meterWidth);
  plotLinear(&tft, "TDS(ppm)", 1*meterDistance, meterHeight, meterWidth);
  plotLinear(&tft, "pH", 2*meterDistance, meterHeight, meterWidth);

  delay(1000);
  
  if (! rtc.begin()) 
  {
    Serial.println("Couldn't find RTC");
    Serial.flush();
    abort();
  }

  updateTime = millis(); // Next update time

  Serial.begin(9600);

  pinMode(lcdDelPin, OUTPUT);
  digitalWrite(lcdDelPin, HIGH);
  pinMode(ECPin,INPUT);
  pinMode(ECPower,OUTPUT);//Setting pin for sourcing current
  pinMode(ECGround,OUTPUT);//setting pin for sinking current
  digitalWrite(ECGround,LOW);//We can leave the ground connected permanantly
  digitalWrite(ECPower,LOW);

  SerialBT.begin("PoolAnalyserPro");
  drawMinMax(tempMax, tempMin, tdsMax, tdsMin, phMax, phMin, &tft);
  delay(200);
  DateTime zero = DateTime(0,0,0,0,0,0);
  rtc.adjust(zero);

}

void loop() 
{
    static int eventSendTime;
    static bool sendingEvents = false;
    static bool appConnected;
    static int appConnectedTime;
    static int eventShowTime = millis();
    static int nEvent;
    static float temperature;
    static float tds;
    static float pH;

    //Refresh pointer display
    if (abs(millis() - updateTime > LOOP_PERIOD)) 
    {
        updateTime = millis();
        plotPointer(&tft, value, valueDouble, old_value, meterDistance, meterWidth);
    }

    // Acquisition de temperature et TDS
    if(millis() - tdsTime > 5000)
    {
        tdsTime = millis();

        temperature = getTemperature(&sensors);
        //Serial.println(temperature);
        value[0] = (int)temperature;
        valueDouble[0] = (double)temperature;
        sendTemperature(temperature, &SerialBT); 

        tds = GetEC(temperature, &unwantedEventVector);
        value[1] = (int)tds;
        valueDouble[1] = (double)tds;
        sendTds(tds, &SerialBT);
    }

    // Acquisition de pH
    if(abs(millis() - phTime) > 1000)
    {
        phTime = millis();
        
        pH = getPh(PH_PIN);
        value[2] = (int)pH;
        valueDouble[2] = (double)pH;
        sendPh(pH);

        if(pH > phMax)
        {
          sendPhTooHigh(pH);
          UnwantedEvent ph2HighEvent;
          ph2HighEvent.type = "pH";
          ph2HighEvent.highLow = "High";
          ph2HighEvent.value = pH;
          ph2HighEvent.time = rtc.now();
          unwantedEventVector.push_back(ph2HighEvent);
        }
        if(pH < phMin)
        {
          sendPhTooLow(pH);
          UnwantedEvent ph2LowEvent;
          ph2LowEvent.type = "pH";
          ph2LowEvent.highLow = "Low";
          ph2LowEvent.value = pH;
          ph2LowEvent.time = rtc.now();
          unwantedEventVector.push_back(ph2LowEvent);
        }
        }

    }

    // Affichage de date et heure
    if(abs(millis() - showTime) > 500)
    {
        showTime = millis();
        printTime(rtc.now(), &tft, 5, 28);
    }

    if(abs(millis() - eventShowTime) > 3000 && unwantedEventVector.size() > 0)
    {
      eventShowTime = millis();
      printEvent(unwantedEventVector, nEvent);

      nEvent++;
      if(nEvent > unwantedEventVector.size() - 1)
      {
        nEvent = 0;
      }
    }

    if(deleteEvents)
    {
      unwantedEventVector.clear();
      tft.fillRect(106, 39, 130, 58, TFT_GREY);
      nEvent = 0;
      deleteEvents = false;
    }

    // if(requestEvents)
    // {
    //   for(int i = 0; i < unwantedEventVector.size(); i++)
    //   {
    //     SerialBT.print(eventToSendVector[i] + String('\n'));
    //   }

    //   requestEvents = false;
    // }


   
    if(minMaxChanged)
    {
        drawMinMax(tempMax, tempMin, tdsMax, tdsMin, phMax, phMin, &tft);
        minMaxChanged = false;
    }

}


void printEvent(vector<UnwantedEvent> eventVector, int n)
{
    tft.fillRect(106, 39, 130, 10, TFT_BLACK);
    tft.fillRect(106, 51, 130, 10, TFT_BLACK);
    tft.fillRect(106, 63, 130, 10, TFT_BLACK);
    tft.fillRect(106, 75, 130, 10, TFT_BLACK);
    tft.fillRect(106, 87, 130, 10, TFT_BLACK);
    tft.setCursor(107, 40);
    tft.setTextColor(TFT_CYAN);
    tft.print("Showing event #" + String(n + 1) + "/" + String(unwantedEventVector.size()));
    tft.setCursor(107, 52);
    tft.print("Type : ");
    tft.setCursor(107, 64);
    tft.print("H/L : ");
    tft.setCursor(107, 76);
    tft.print("Value: ");
    tft.setCursor(107, 88);
    tft.print("Date : ");

    tft.setTextColor(TFT_GREEN);

    tft.setCursor(145, 52);
    tft.print(eventVector[n].type);
    tft.setCursor(145, 64);
    tft.print(eventVector[n].highLow);
    tft.setCursor(145, 76);
    tft.print(eventVector[n].value);
    
    printTime(eventVector[n].time, &tft, 145 , 88);
}

//************ This Loop Is called From Main Loop************************//
float GetEC(float temperature, vector<UnwantedEvent>* vector)
{
  static int tempEventTime;
  static float tdsTemp;
  static float tdsReadings[10];
  static int noRead;
  Serial.println("1 " + String(temperature));

  //*********Reading Temperature Of Solution *******************//
  
  if(abs(millis() - tempEventTime) > UNWANTEDEVENTBREAK)
  {
    tempEventTime = millis();
    if(temperature < tempMin)
    {
      sendTemperatureTooLow(Temperature);
    }
    if(temperature > tempMax)
    {
      sendTemperatureTooHigh(temperature);
      
      UnwantedEvent temp2HighEvent;

      temp2HighEvent.type = "Temp";
      temp2HighEvent.highLow = "High";
      temp2HighEvent.value = temperature;
      temp2HighEvent.time = rtc.now();

      unwantedEventVector.push_back(temp2HighEvent);
      
    }
  }

  //************Estimates Resistance of Liquid ****************//
  digitalWrite(ECPower,HIGH);
  raw = analogRead(ECPin);
  digitalWrite(ECPower,LOW);

   
  //***************** Converts to EC **************************//
  Vdrop= (Vin*raw)/4095.0;
  Rc=(Vdrop*R1)/(Vin-Vdrop);
  Rc=Rc-Ra; //acounting for Digital Pin Resitance
  EC = 1000/(Rc*K);
  //*************Compensating For Temperature********************//
  EC25  =  EC/ (1+ TemperatureCoef*(temperature-25.0));

//Serial.println(ppm);
 ppm = ec2Tds(EC25);
 tdsReadings[nReadings] = ppm;

  ppmSum+=ppm;

  nReadings++;
  if(nReadings == 10)
  {

    for(int i=0;i<9;i++)
    {
     for(int j=i+1;j<10;j++)
     {
      if(tdsReadings[i]>tdsReadings[j])
      {
        tdsTemp=tdsReadings[i];
        tdsReadings[i]=tdsReadings[j];
        tdsReadings[j]=tdsTemp;
      }
     }
    }

    meanPpm = 0;
    for(int i=3;i<7;i++)
    {
      meanPpm += tdsReadings[i];
    }
    meanPpm = meanPpm/4;

    ppmSum = 0;
    nReadings = 0;
    sendTds(valueDouble[1], &SerialBT);
    noRead++;

    if(meanPpm > tdsMax)
    {
      UnwantedEvent tds2HighEvent;
      sendTdsTooHigh(meanPpm);
      tds2HighEvent.type = "Tds";
      tds2HighEvent.highLow = "High";
      tds2HighEvent.value = tds;
      tds2HighEvent.time = rtc.now();  
      vector->push_back(tds2HighEvent);
    }


  }


  if(meanPpm > 0)
  {
    return meanPpm;
  }
  else 
  {
      return 1;
  }

}

void sendTemperatureTooLow(float temperature)
{ 
  String eventMessage;
  DateTime now = rtc.now();

  eventMessage = "tl_" + sendTempString(temperature) + sendTimeString(now) + String('\n');


  SerialBT.print(eventMessage);
  eventToSendVector.push_back(eventMessage);

}

void sendTemperatureTooHigh(float temperature)
{
  String eventMessage;
  DateTime now = rtc.now();
Serial.println(temperature);
  eventMessage = "th_" + sendTempString(temperature) + sendTimeString(now) + String('\n');

  SerialBT.print(eventMessage);
  eventToSendVector.push_back(eventMessage);

}

void sendTdsTooLow(float tds)
{ 
  String eventMessage;
  DateTime now = rtc.now();

  eventMessage = "sl_" + sendTdsString(tds) + sendTimeString(now) + String('\n');
  

  SerialBT.print(eventMessage);
  eventToSendVector.push_back(eventMessage);

}

void sendTdsTooHigh(float tds)
{
  String eventMessage;
  DateTime now = rtc.now();

  eventMessage = "sh_" + sendTdsString(tds) + sendTimeString(now) + String('\n');


  SerialBT.print(eventMessage);
  eventToSendVector.push_back(eventMessage);


}

void sendPhTooLow(float ph)
{ 
  String eventMessage;
  DateTime now = rtc.now();

  eventMessage = "hl_" + sendTempString(ph) + sendTimeString(now) + String('\n');
  
  SerialBT.print(eventMessage);
  eventToSendVector.push_back(eventMessage);
}

void sendPhTooHigh(float ph)
{
  String eventMessage;
  DateTime now = rtc.now();

  eventMessage = "hh_" + sendTempString(ph) + sendTimeString(now) + String('\n');


 

  SerialBT.print(eventMessage);
  eventToSendVector.push_back(eventMessage);


}

String sendTdsString(double tds)
{
  int tdsInt = (int)tds;
  String tdsString;
    if(tds > 999)
    {
      tdsString = "";
    }
    else if(tds > 99)
    {
      tdsString = "0";
    }
    else if(tds > 9)
    {
      tdsString = "00";
    }
    else
    {
      tdsString = "000";
    }

    tdsString += String(tdsInt);
    
    return tdsString;
}

void sendPh(double ph)
{
    String phSend;
    int BtValue = (int)(round(ph*10));
    

    if(BtValue/10 > 9)
    {
      phSend = "ph_" + String(BtValue) + String('\n');
    }
    else if(BtValue/10 > 0.9)
    {
      phSend = "ph_0" + String(BtValue) + String('\n');
    }
    else
    {
      phSend = "ph_00" + String(BtValue) + String('\n');
    }
    
    SerialBT.print(phSend);
}

void btRxTaskCode( void * pvParameters )
{

  for(;;)
  {
     int receivedSecond;
     int receivedMinute;
     int receivedHour;
     int receivedDay;
     int receivedMonth;
     String messagePrefix;
     DateTime applicationTime;

    if(SerialBT.available())
    {
      btReceivedChar = SerialBT.read();
      if(btReceivedChar != '\n')
      {
        btReceivedString += String(btReceivedChar);
      }
      else
      {
        messagePrefix = btReceivedString.substring(0,2);

        // Time
        if(messagePrefix == "tm")
        {
          //Time message = tm_ssmmhhddMM
          //Position :     0123456789ABC
          // Test : tm_1122334455
          receivedSecond = btReceivedString.substring(3, 5).toInt();
          receivedMinute = btReceivedString.substring(5, 7).toInt();
          receivedHour = btReceivedString.substring(7, 9).toInt();
          receivedDay = btReceivedString.substring(9, 11).toInt();
          receivedMonth = btReceivedString.substring(11, 13).toInt();


          applicationTime = DateTime(2021, receivedMonth, receivedDay, receivedHour, receivedMinute, receivedSecond);
          rtc.adjust(applicationTime);
          btReceivedString = "";
        }
        // Min and max update 
        if(messagePrefix == "mm")
        {
          tempMax = btReceivedString.substring(3, 6).toDouble()/10;
          tempMin = btReceivedString.substring(6, 9).toDouble()/10;

          tdsMax = btReceivedString.substring(9, 13).toDouble();
          tdsMin = btReceivedString.substring(13, 17).toDouble();

          phMax = btReceivedString.substring(17, 20).toDouble()/10;
          phMin = btReceivedString.substring(20, 23).toDouble()/10;
          minMaxChanged = true;
          btReceivedString = "";
        }
        if(messagePrefix == "dl")
        {
          deleteEvents = true;
        }
        else
        {
          btReceivedString = "";
        }
      }
    }

  }
}