#include "BluetoothSerial.h"
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

BluetoothSerial SerialBT;

// Pantalla OLED
#define ANCHO 128
#define ALTO 64
#define ADDRESS 0x3C
Adafruit_SSD1306 display(ANCHO, ALTO, &Wire, -1);

void setup() {
  Serial.begin(115200);
  SerialBT.begin("RobotMascota"); // Nombre visible en BT clásico
  display.begin(SSD1306_SWITCHCAPVCC, ADDRESS);
  display.clearDisplay();
  display.setTextSize(2);
  display.setTextColor(SSD1306_WHITE);
  display.println("Conectando...");
  display.display();
}

void loop() {
  if (SerialBT.available()) {
    String data = SerialBT.readStringUntil('\n');
    data.trim();  // Limpia espacios

    Serial.println("Recibido: " + data);  // Ver en monitor serie

    if (data == "feliz") {
      mostrarFeliz();
    } else if (data == "sueno") {
      mostrarSueno();
    } else if (data == "idle") {
      mostrarIdle();
    } else {
      display.clearDisplay();
      display.setCursor(0, 0);
      display.println("Comando desconocido");
      display.display();
    }
  }
}

void mostrarFeliz() {
  display.clearDisplay();
  display.setCursor(20, 20);
  display.println(":D");
  display.display();
}

void mostrarSueno() {
  display.clearDisplay();
  display.setCursor(20, 20);
  display.println("-_-");
  display.display();
}

void mostrarIdle() {
  display.clearDisplay();
  display.setCursor(20, 20);
  display.println("o.o");
  display.display();
}
