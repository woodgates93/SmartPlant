import serial
import json

def readSerialData():
    #Inittialize serial Com. - USB input and settings
    ser = serial.Serial('/dev/ttyACM0', 9600)

    #Clears the buffer
    ser.reset_input_buffer()

    try:
        buffer =b''
        while True:
        #Checks if there is data in the buffer
            if ser.in_waiting > 0:
            #Reads data in buffer and "formats" it
                dataReadings = ser.read(ser.in_waiting)
                buffer += dataReadings

                if b'\n' in buffer:
                    lines = buffer.split(b'\n')
                    for line in lines[:-1]:
                        line = line.decode(errors='replace').strip()
                        jsonData = json.loads(line)
                        stringData = json.dumps(jsonData, ensure_ascii=False)
                        return stringData
                    buffer = lines[-1]
    except serial.SerialException as se:
                print(f"Serial port exception: {se}")
    finally:
                ser.close()
#For testing only - remove when done
data = readSerialData()
print(data)