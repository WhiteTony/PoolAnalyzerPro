/*
  Example animated analogue meters using a ILI9341 TFT LCD screen

  Needs Font 2 (also Font 4 if using large scale label)

  Make sure all the display driver and pin comnenctions are correct by
  editting the User_Setup.h file in the TFT_eSPI library folder.

  #########################################################################
  ###### DON'T FORGET TO UPDATE THE User_Setup.h FILE IN THE LIBRARY ######
  #########################################################################
*/

 #include "TFT_Meters.h"

void topDisplay(TFT_eSPI* tft)
{
  tft->fillRect(0, 0, 239, 126, TFT_GREY);
  tft->fillRect(1, 1, 237, 124, TFT_BLACK);
  tft->fillRect(2, 2, 235, 122, TFT_GREY);
  tft->fillRect(60, 4, 110, 10, TFT_BLACK);
  tft->setCursor(65, 5);
  tft->setTextColor(TFT_CYAN);
  tft->print("Pool Analyser Pro");
  tft->setCursor(5,5);
  tft->fillRect(4, 15, 80, 10, TFT_BLACK);
  tft->setCursor(5, 16);
  tft->print("Date and time");

  tft->fillRect(4, 39, 100, 10, TFT_BLACK);
  tft->setCursor(5, 40);
  tft->print("Temp max :");

  tft->fillRect(4, 51, 100, 10, TFT_BLACK);  
  tft->setCursor(5, 52);
  tft->print("Temp min :");

  tft->fillRect(4, 63, 100, 10, TFT_BLACK);  
  tft->setCursor(5, 64);
  tft->print("TDS max  :");

  tft->fillRect(4, 75, 100, 10, TFT_BLACK);  
  tft->setCursor(5, 76);
  tft->print("TDS min  :");

  tft->fillRect(4, 87, 100, 10, TFT_BLACK);  
  tft->setCursor(5, 88);
  tft->print("pH max   :");

  tft->fillRect(4, 99, 100, 10, TFT_BLACK);  
  tft->setCursor(5, 100);
  tft->print("pH min   :");
}



// #########################################################################
//  Draw a linear meter on the screen
// #########################################################################
void plotLinear(TFT_eSPI* tft, char *label, int x, int y, int meterWidth)
{
  tft->drawRect(x, y, meterWidth, 155, TFT_GREY);
  tft->fillRect(x + 2, y + 19, meterWidth-4, 155 - 38, TFT_GREY);
  tft->setTextColor(TFT_CYAN, TFT_BLACK);
  tft->drawCentreString(label, x + meterWidth / 2, y + 2, 2);

  for (int i = 0; i < 110; i += 10)
  {
    tft->drawFastHLine(x + 20, y + 27 + i, 6, TFT_WHITE);
  }

  for (int i = 0; i < 110; i += 50)
  {
    tft->drawFastHLine(x + 20, y + 27 + i, 9, TFT_WHITE);
  }

  tft->fillTriangle(x + 3, y + 127, x + 3 + 16, y + 127, x + 3, y + 127 - 5, TFT_RED);
  tft->fillTriangle(x + 3, y + 127, x + 3 + 16, y + 127, x + 3, y + 127 + 5, TFT_RED);

  tft->drawCentreString("---", x + meterWidth / 2, y + 155 - 18, 2);
}
// #########################################################################
//  Adjust 6 linear meter pointer positions
// #########################################################################
void plotPointer(TFT_eSPI* tft, int* value, double* valueDouble, int* oldValue, int meterDistance, int meterWidth)
{
  int dy = 187;
  byte pw = 16;
  int phValueToShow = 0;
  int phOldValue = 0;
  


  tft->setTextColor(TFT_GREEN, TFT_BLACK);

  // Move the 3 pointers one pixel towards new value
  for (int i = 0; i < 3; i++)
  {
    int dx = 3 + meterDistance * i;

    if(i==0)
    {
      char buf[8]; dtostrf(valueDouble[i], 5, 1, buf);
      tft->drawRightString(buf, (i*meterDistance) + meterWidth/2 + 10, 187 - 27 + 155 - 18, 2);

      if (value[i] < 0) value[i] = 0; // Limit value to emulate needle end stops
      if (value[i] > 99) value[i] = 99;

      while (!(value[i] == oldValue[i])) 
      {
        dy = 187 + 100 - oldValue[i];
        if (oldValue[i] > value[i])
        {
          tft->drawLine(dx, dy - 5, dx + pw, dy, TFT_GREY);
          oldValue[i]--;
          tft->drawLine(dx, dy + 6, dx + pw, dy + 1, TFT_RED);
        }
        else
        {
          tft->drawLine(dx, dy + 5, dx + pw, dy, TFT_GREY);
          oldValue[i]++;
          tft->drawLine(dx, dy - 6, dx + pw, dy - 1, TFT_RED);
        }
      } 
    }
    if(i==1)
    {
      char buf[8]; dtostrf(valueDouble[i], 5, 0, buf);
      tft->drawRightString(buf, (i*meterDistance) + meterWidth/2 + 10, 187 - 27 + 155 - 18, 2);

      if (value[i] < 0) value[i] = 0; // Limit value to emulate needle end stops
      if (value[i] > 2499) value[i] = 2499;

      while (!(value[i]*100/3000 == oldValue[i]*100/3000)) 
      {
        dy = 187 + 100 - oldValue[i]*100/3000;
        if (oldValue[i] > value[i])
        {
          tft->drawLine(dx, dy - 5, dx + pw, dy, TFT_GREY);
          oldValue[i]--;
          tft->drawLine(dx, dy + 6, dx + pw, dy + 1, TFT_RED);
        }
        else
        {
          tft->drawLine(dx, dy + 5, dx + pw, dy, TFT_GREY);
          oldValue[i]++;
          tft->drawLine(dx, dy - 6, dx + pw, dy - 1, TFT_RED);
        }
      }
    }
    if(i==2)
    {
      char buf[8]; dtostrf(valueDouble[i], 5, 1, buf);

      tft->drawRightString(buf, (i*meterDistance) + meterWidth/2 + 10, 187 - 27 + 155 - 18, 2);

      if (value[i] < 0) value[i] = 0; // Limit value to emulate needle end stops
      if (value[i] > 14) value[i] = 14;

      phValueToShow = value[2];
      phOldValue = oldValue[2];

      while (!(phValueToShow == phOldValue)) 
      {
        dy = 187 + 100 - phOldValue;
        if (phOldValue > phValueToShow)
        {
          tft->drawLine(dx, dy - 5, dx + pw, dy, TFT_GREY);
          phOldValue--;
          tft->drawLine(dx, dy + 6, dx + pw, dy + 1, TFT_RED);
        }
        else
        {
          tft->drawLine(dx, dy + 5, dx + pw, dy, TFT_GREY);
          phOldValue++;
          tft->drawLine(dx, dy - 6, dx + pw, dy - 1, TFT_RED);
        }      
      }
    }
  }
}

