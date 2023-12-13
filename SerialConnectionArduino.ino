#include <ArduinoJson.h>

//Water Sensor
#define POWERPIN 7
#define WSPIN A0

//Light resister
#define KYPOWERPIN 4
#define KYPIN A2

int id = 2;

int w = 0; //water sensor values
int l = 0; //light sensor values

void setup() {
  Serial.begin(9600);
  pinMode(POWERPIN, OUTPUT);
  digitalWrite(POWERPIN, LOW);

  pinMode(KYPOWERPIN, OUTPUT);
  digitalWrite(KYPOWERPIN, HIGH);
}

void loop() {
  //Water Sensor
  digitalWrite(POWERPIN, HIGH);
  w = analogRead(WSPIN);
  digitalWrite(POWERPIN, LOW);
  if(isnan(w)) {
      Serial.println("Failed to read from Water Sensor");
      return;
    }

  //Light Resistor
  digitalWrite(KYPOWERPIN, HIGH);
  l = analogRead(KYPIN);  
  digitalWrite(POWERPIN, LOW);
  if(isnan(l)) {
      Serial.println("Failed to read from Light Resistor Sensor");
      return;
    }

  //Data as Json
  DynamicJsonDocument JsonDocument(200);

  JsonDocument["id"]=id;
  JsonDocument["waterlevel"]=w;
  JsonDocument["lightresistance"]=l; 
  
  serializeJson(JsonDocument, Serial);
  Serial.println();

  delay(500);  
}
