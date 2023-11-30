from socket import *
from sense_hat import SenseHat 
from time import sleep

broadcastPort = 6666


#methods
def getMeasurement():
    sensehat = SenseHat()
    measurement = sensehat.get_temperature_from_humidity()
    return measurement



broadcastsocket = socket (AF_INET, SOCK_DGRAM)

broadcastsocket.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

while True:
    data = str(getMeasurement())
    encodeddata = data.encode('utf-8')
    broadcastsocket.sendto(encodeddata, ('<broadcast>', broadcastPort))
    sleep(1)


