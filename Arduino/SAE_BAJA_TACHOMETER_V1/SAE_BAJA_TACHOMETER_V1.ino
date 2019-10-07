//Note that the wheel encoder has 6 pins
//              engine encoder:   5 pins
// Conversion to RPM = Hz (output/printed) * 60 * 1/messageInterval_millis*1/num_magnets=rpm
// Error = +- (60*1/num_magnets * 1/messageInterval_millis) RPM

#define wheelEncoderInterruptPin 0
#define engineEncoderInterruptPin 1
#define messageInterval_millis 250

long wheelPulseCount;
long enginePulseCount;
long timeToSendMessage;

void wheelInterruptFunction(){
  wheelPulseCount++;
}

void engineInterruptFunction(){
  enginePulseCount++;
}

void setup() {
  // put your setup code here, to run once:
  attachInterrupt(wheelEncoderInterruptPin, wheelInterruptFunction, RISING);
  attachInterrupt(engineEncoderInterruptPin, engineInterruptFunction, RISING);
  Serial.begin(115200); // BAUD rate for Serial Communication
  wheelPulseCount = 0; //Reset
  enginePulseCount = 0;
  timeToSendMessage = millis() + messageInterval_millis;
}

void loop() {
  // put your main code here, to run repeatedly:
  if(millis()>timeToSendMessage){
    Serial.print(wheelPulseCount);
    Serial.print("\t");
    Serial.println(enginePulseCount);
    wheelPulseCount = 0;
    enginePulseCount = 0;
    timeToSendMessage = millis()+ messageInterval_millis;
  }
  
}
