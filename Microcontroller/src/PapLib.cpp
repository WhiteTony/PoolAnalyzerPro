#include <event.h>


float ec2Tds(float ec25)
{

  float ec2Ppm;

  if(ec25 < 0.3)
  {
    ec2Ppm = 0.5;
  }
  else if(ec25 < 0.75)
  {
    ec2Ppm = 0.6;
  }
  else if(ec25 < 1.25)
  {
    ec2Ppm = 0.65;
  }
  else if(ec25 < 1.75)
  {
    ec2Ppm = 0.7;
  }
  else if(ec25 < 2.25)
  {
    ec2Ppm = 0.72;
  }
  else if(ec25 < 2.75)
  {
    ec2Ppm = 0.74;
  }
  else if(ec25 < 3.25)
  {
    ec2Ppm = 0.75;
  }
  else if(ec25 < 3.75)
  {
    ec2Ppm = 0.75;
  }
  else if(ec25 < 4.25)
  {
    ec2Ppm = 0.77;
  }
  else
  {
    ec2Ppm = 0.8;
  }

    return ec25*ec2Ppm*1000;
}

float getPh(int poPin)
{
    static float buf[10];
    static float avgValue;
    float temp;
    float phValue;

    for(int i=0;i<10;i++) 
    { 
        buf[i]=analogRead(poPin);
        delay(10);
    }
    
    for(int i=0;i<9;i++)
    {
        for(int j=i+1;j<10;j++)
        {
            if(buf[i]>buf[j])
            {
                temp=buf[i];
                buf[i]=buf[j];
                buf[j]=temp;
            }
        }
    }

    avgValue=0;
    for(int i=2;i<8;i++)
    avgValue+=buf[i];
    float pHVol=(float)avgValue/6;
   // Serial.println(pHVol);
    return phValue = -0.00357 * pHVol + 19.53076923;
}

float getTemperature(DallasTemperature* sensor)
{
    float temperature;
    sensor->requestTemperatures();
    temperature = sensor->getTempCByIndex(0);
    if(abs(temperature) > 99 || temperature < 0)
    {
      temperature = 1;
    }
    return temperature;
}

// Envoie une valeur de temperature par bluetooth
void sendTemperature(double temperature, BluetoothSerial* SerialBT)
{
    
    String tempSend = "tp_" + sendTempString(temperature) + String('\n');
    SerialBT->print(tempSend);
}

void sendTds(double tds, BluetoothSerial* SerialBT)
{
    String tdsSend;
    String tdsPrefix = "td_";
    int BTValue = (int)tds;

    tdsSend = tdsPrefix + sendTdsString(tds) + String('\n');
    SerialBT->print(tdsSend);
}

// Transforme une valeur de temperature en string pret pour etre envoye 
// par Bluetooth
// i.e une temperature de 12.3 devient 0123, qui peut ensuite etre 
// utilise dans un message tp_0123
String sendTempString(double temperature)
{
    int tempInt = (int)(temperature*10);
    String temperatureString;

    if(temperature > 9.999)
    {
        temperatureString = "0";
    }
    else if(temperature > 0.99999)
    {
        temperatureString = "00";
    }
    else
    {
        temperatureString = "000";
    }       
    temperatureString += String(tempInt);

    return temperatureString;
}

// Transforme une valeur de pH en string pret pour etre envoye par Bluetooth
// i.e un pH de 12.3 devient 123, qui peut ensuite etre utilise dans un
// message ph_123
String sendPhString(float ph)
{
    String phString;
    String phIntString = String((int)(ph*10));

    if(ph > 9)
    {
      phString = String(phIntString) + String('\n');
    }
    else if(ph > 0.9)
    {
      phString = "ph_0" + String(phIntString) + String('\n');
    }
    else
    {
      phString = String(phIntString) + String('\n');
    }
}

//Fonctions d'affichage
void printTime(DateTime now, TFT_eSPI* tft, int x, int y)
{
    tft->setTextColor(TFT_GREEN);
    tft->fillRect(x - 1, y - 1, 85, 10, TFT_BLACK);
   // tft->fillRect(x + 85, y - 1, 50, 10, TFT_GREY);
    tft->setCursor(x, y);

    if(now.day() > 9)
    {
        tft->print(now.day(), DEC);
    }
    else
    {
        String dayString = "0" + String(now.day(), DEC);
        tft->print(dayString);
    }

    tft->print("/");

    if(now.month() > 9)
    {
        tft->print(now.month(), DEC);
    }
    else
    {
        String monthString = "0" + String(now.month(), DEC); 
        tft->print(monthString);
    }

    tft->print(" ");

    if(now.hour() > 9)
    {
        tft->print(now.hour(), DEC);
    }
    else 
    {
        String hourString = "0" + String(now.hour(), DEC); 
        tft->print(hourString);
    }

    tft->print(":");

    if(now.minute() > 9)
    {
        tft->print(now.minute(), DEC);
    }
    else 
    {
        String minuteString = "0" + String(now.minute(), DEC); 
        tft->print(minuteString);
    }

    tft->print(":");

    if(now.second() > 9)
    {
        tft->print(now.second(), DEC);
    }
    else 
    {
        String secondString = "0" + String(now.second(), DEC); 
        tft->print(secondString);
    }

}


void drawMinMax(double tempMax, double tempMin, int tdsMax, int tdsMin, double phMax, double phMin, TFT_eSPI* tft)
{
  tft->fillRect(65, 39, 30, 10, TFT_BLACK);
  tft->fillRect(65, 51, 30, 10, TFT_BLACK);  
  tft->fillRect(65, 63, 30, 10, TFT_BLACK);
  tft->fillRect(65, 75, 30, 10, TFT_BLACK);
  tft->fillRect(65, 87, 30, 10, TFT_BLACK);
  tft->fillRect(65, 99, 30, 10, TFT_BLACK);

  tft->setTextColor(TFT_GREEN);
  tft->setCursor(65, 40);
  tft->print(tempMax);

  tft->setCursor(65, 52);
  tft->print(tempMin);

  tft->setCursor(65, 64);
  tft->print(tdsMax);

  tft->setCursor(65, 76);
  tft->print(tdsMin);

  tft->setCursor(65, 88);
  tft->print(phMax);

  tft->setCursor(65, 100);
  tft->print(phMin);
}

String sendTimeString(DateTime time)
{
  String secondString;
  String minuteString;
  String hourString;
  String dayString;
  String monthString;
  String timeString;

  if(time.second() > 9)
  {
    secondString = String(time.second(), DEC);
  }
  else 
  {
    secondString = "0" + String(time.second(), DEC);
  }



  if(time.minute() > 9)
  {
    minuteString = String(time.minute(), DEC);
  }
  else 
  {
    minuteString = "0" + String(time.minute(), DEC);
  }

  if(time.hour() > 9)
  {
    hourString = String(time.hour(), DEC);
  }
  else 
  {
    hourString = "0" + String(time.hour(), DEC);
  }

  if(time.day() > 9)
  {
    dayString = String(time.day(), DEC);
  }
  else 
  {
    dayString = "0" + String(time.day(), DEC);
  }

  if(time.month() > 9)
  {
    monthString = String(time.month(), DEC);
  }
  else 
  {
    monthString = "0" + String(time.month(), DEC);
  }

  timeString = secondString + minuteString + hourString + dayString + monthString;

  return timeString; 

}

