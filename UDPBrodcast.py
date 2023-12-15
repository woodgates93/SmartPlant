from socket import *
#from sense_hat import SenseHat 
from time import sleep
from SerialConnection import readSerialData

broadcastPort = 6666

broadcastsocket = socket (AF_INET, SOCK_DGRAM)
broadcastsocket.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

while True:
    data = readSerialData()
    encodeddata = data.encode('utf-8')
    broadcastsocket.sendto(encodeddata, ('255.255.255.255', broadcastPort))
    sleep(1)

